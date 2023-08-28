using DoctorNotesService.Controllers;
using DoctorNotesService.Models;
using DoctorNotesService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediscreenTests
{
    public class NotesControllerTest
    {
        [Fact]
        public async Task GetAsync_ShouldReturnAllNotes()
        {
            // ARRANGE
            var mockNoteService = new Mock<INoteService>();
            var expectedNotes = new List<Note>
            {
                new Note 
                {
                    Id = "54E62K71E94L9E87B5FI4ND4",
                    PatientId = 1,
                    DoctorId = 4,
                    NoteContent = "this is the note content for patient 1."
                },
                new Note
                {
                    Id = "7DB7CF38430D8F7E10EA1FE7",
                    PatientId = 2,
                    DoctorId = 1,
                    NoteContent = "this is the note content for patient 2."
                }

            };

            mockNoteService.Setup(service => service.GetAsync())
                .ReturnsAsync(expectedNotes);

            var controller = new NotesController(mockNoteService.Object);

            // ACT
            var result = await controller.GetAsync();

            // ASSERT
            var actualNotes = Assert.IsAssignableFrom<List<Note>>(result);
            Assert.Equal(expectedNotes.Count, actualNotes.Count);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnSpecifiedNote()
        {
            // ARRANGE
            var mockNoteService = new Mock<INoteService>();
            var expectedNote = new Note
            {
                    Id = "824279A3B463F2E23AB5841D",
                    PatientId = 5,
                    DoctorId = 2,
                    NoteContent = "this is the note content for patient 5."
            };

            mockNoteService.Setup(service => service.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedNote);

            var controller = new NotesController(mockNoteService.Object);

            // ACT
            var result = await controller.GetByIdAsync(expectedNote.Id);

            // ASSERT
            var resultType = Assert.IsType<ActionResult<Note>>(result);
            var actualNote = Assert.IsType<Note>(resultType.Value);
            Assert.Equal(expectedNote.Id, actualNote.Id);
        }

        [Fact]
        public async Task GetByPatientIdAsync_ShouldReturnAllNotesForSpecifiedPatient()
        {
            // ARRANGE
            var mockNoteService = new Mock<INoteService>();
            var expectedNotes = new List<Note>
            {
                new Note
                {
                    Id = "F820F90A9B7EDDC101E6BC40",
                    PatientId = 1,
                    DoctorId = 1,
                    NoteContent = "this is the first note content for patient 1."
                },
                new Note
                {
                    Id = "A5A64D1D9E758C8A6E639142",
                    PatientId = 1,
                    DoctorId = 1,
                    NoteContent = "this is another note content for patient 1."
                },
                new Note
                {
                    Id = "68366F4C0D435E167666C84C",
                    PatientId = 2,
                    DoctorId = 1,
                    NoteContent = "this is the note content for patient 2."
                },
            };

            var patientId = 1;
            var expectedPatientNotes = expectedNotes.Where(note => note.PatientId == patientId).ToList();

            mockNoteService.Setup(service => service.GetByPatientIdAsync(patientId))
                .ReturnsAsync(expectedPatientNotes);

            var controller = new NotesController(mockNoteService.Object);

            // ACT
            var result = await controller.GetByPatientIdAsync(patientId);

            // ASSERT
            var resultType = Assert.IsType<ActionResult<List<Note>>>(result);
            var actualNote = Assert.IsType<List<Note>>(resultType.Value);
            Assert.Equal(2,actualNote.Count);
        }

        [Fact]
        public async Task GetByDoctorIdAsync_ShouldReturnAllNotesFromSpecifiedDoctor()
        {
            // ARRANGE
            var mockNoteService = new Mock<INoteService>();
            var expectedNotes = new List<Note>
            {
                new Note
                {
                    Id = "F820F90A9B7EDDC101E6BC40",
                    PatientId = 1,
                    DoctorId = 1,
                    NoteContent = "this is the first note content for patient 1."
                },
                new Note
                {
                    Id = "A5A64D1D9E758C8A6E639142",
                    PatientId = 1,
                    DoctorId = 1,
                    NoteContent = "this is another note content for patient 1."
                },
                new Note
                {
                    Id = "68366F4C0D435E167666C84C",
                    PatientId = 1,
                    DoctorId = 2,
                    NoteContent = "this is the note content for patient 2."
                },
            };

            var doctorId = 1;
            var expectedDoctorNotes = expectedNotes.Where(note => note.DoctorId == doctorId).ToList();

            mockNoteService.Setup(service => service.GetByDoctorIdAsync(doctorId))
                .ReturnsAsync(expectedDoctorNotes);

            var controller = new NotesController(mockNoteService.Object);

            // ACT
            var result = await controller.GetByDoctorIdAsync(doctorId);

            // ASSERT
            var resultType = Assert.IsType<ActionResult<List<Note>>>(result);
            var actualNote = Assert.IsType<List<Note>>(resultType.Value);
            Assert.Equal(2, actualNote.Count);
        }

        [Fact]
        public async Task PostAsync_ShouldCreateNewNote()
        {
            // ARRANGE
            var mockNoteService = new Mock<INoteService>();
            var expectedNote = new Note
            {
                Id = "932C1BBAF4D71C131A4DE6B2",
                PatientId = 1,
                DoctorId = 1,
                NoteContent = "this is the note content for patient 1."
            };

            mockNoteService.Setup(service => service.CreateAsync(It.IsAny<Note>()))
               .ReturnsAsync(expectedNote);

            var controller = new NotesController(mockNoteService.Object);

            // ACT
            var result = await controller.PostAsync(expectedNote);

            // ASSERT
            //var resultType = Assert.IsType<ActionResult<Note>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var actualNote = Assert.IsAssignableFrom<Note>(createdAtActionResult.Value);
            Assert.Equal(expectedNote.Id, actualNote.Id);
        }

        [Fact]
        public async Task PutAsync_ShouldUpdateSpecifiedNote()
        {
            // ARRANGE
            var mockNoteService = new Mock<INoteService>();
            var existingNote = new Note
            {
                Id = "CC3FF72077E7A584A5BB7B7B",
                PatientId = 2,
                DoctorId = 1,
                NoteContent = "this is the note content for patient 2."
            };

            var updatedNote = new Note
            {
                Id = "CC3FF72077E7A584A5BB7B7B",
                PatientId = 2,
                DoctorId = 2,
                NoteContent = "this is the updated note content for patient 2."
            };

            mockNoteService.Setup(service => service.GetByIdAsync(existingNote.Id))
               .ReturnsAsync(existingNote);

            var controller = new NotesController(mockNoteService.Object);

            // ACT
            var result = await controller.PutAsync(existingNote.Id, updatedNote);

            // ASSERT
            var noContentResult = Assert.IsType<NoContentResult>(result);
            mockNoteService.Verify(service => service.UpdateAsync(existingNote.Id, updatedNote), Times.Once);
        }

        [Fact]
        public async Task RemoveAsync_ShouldDeleteSpecifiedNote()
        {
            // ARRANGE
            var mockNoteService = new Mock<INoteService>();
            var existingNote = new Note
            {
                Id = "CC3FF72077E7A584A5BB7B7B",
                PatientId = 2,
                DoctorId = 1,
                NoteContent = "this is the note content for patient 2."
            };

            mockNoteService.Setup(service => service.GetByIdAsync(existingNote.Id))
               .ReturnsAsync(existingNote);

            var controller = new NotesController(mockNoteService.Object);

            // ACT
            var result = await controller.DeleteAsync(existingNote.Id);

            // ASSERT
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            mockNoteService.Verify(service => service.RemoveAsync(existingNote.Id), Times.Once);
            Assert.Equal($"Note with id = {existingNote.Id} was deleted.", okObjectResult.Value);
        }
    }
}
