using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using Newtonsoft.Json;
using PatientDemographicsService.Contracts;
using PatientDemographicsService.Controllers;
using PatientDemographicsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediscreenTests
{
    public class PatientsControllerTests
    {
        [Fact]
        public async Task GetAsync_ReturnsListOfPatients()
        {
            // ARRANGE
            // Create new patients and a mock version of PatientRepository
            var patients = new List<Patient>
            {
                 new Patient
                {
                    Id = 1,
                    FirstName = "Lucas",
                    LastName = "Ferguson",
                    DateOfBirth = new DateTime(1968, 06, 22),
                    Sex = 'M',
                    HomeAdress = "2 Warren Street",
                    PhoneNumber = "387-866-1399"
                },
                 new Patient
                {
                    Id = 2,
                    FirstName = "Pippa",
                    LastName = "Rees",
                    DateOfBirth = new DateTime(1952, 09, 27),
                    Sex = 'F',
                    HomeAdress = "745 West Valley Farms Drive",
                    PhoneNumber = "628-423-0993"
                }
            };

            var mockRepository = new Mock<IPatientRepository>();
            mockRepository.Setup(repo => repo.GetAllPatients()).ReturnsAsync(patients);

            var controller = new PatientsController(mockRepository.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<Patient>>(objectResult.Value);
            Assert.Equal(patients.Count, model.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ExistingId_ReturnsPatient()
        {
            // ARRANGE
            var patientId = 1;
            var patient = new Patient
            {
                Id = patientId,
                FirstName = "Lucas",
                LastName = "Ferguson",
                DateOfBirth = new DateTime(1968, 06, 22),
                Sex = 'M',
                HomeAdress = "2 Warren Street",
                PhoneNumber = "387-866-1399"
            };

            var mockRepository = new Mock<IPatientRepository>();
            mockRepository.Setup(repo => repo.GetPatientById(patientId)).ReturnsAsync(patient);

            var controller = new PatientsController(mockRepository.Object);

            // ACT
            var result = await controller.Details(patientId);

            // ASSERT
            var objectResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<Patient>(objectResult.Value);
            Assert.Equal(patientId, model.Id);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_ReturnsNull()
        {
            // ARRANGE
            var patientId = 10;

            var mockRepository = new Mock<IPatientRepository>();
            mockRepository.Setup(repo => repo.GetPatientById(patientId)).ReturnsAsync((Patient)null);

            var controller = new PatientsController(mockRepository.Object);

            // ACT
            var result = await controller.Details(patientId);

            // ASSERT
            var objectResult = Assert.IsType<ActionResult<Patient>>(result);
            Assert.Null(objectResult.Value);
        }

        [Fact]
        public async Task PutAsync_ShouldReturnNoContent_WhenPatientExists()
        {
            // ARRANGE
            int patientId = 1;
            var existingPatient = new Patient
            {
                Id = patientId,
                FirstName = "Lucas",
                LastName = "Ferguson",
                DateOfBirth = new DateTime(1968, 06, 22),
                Sex = 'M',
                HomeAdress = "2 Warren Street",
                PhoneNumber = "387-866-1399"
            };

            var updatedPatient = new Patient
            {
                Id = patientId,
                FirstName = "Gill",
                LastName = "Ferguson",
                DateOfBirth = new DateTime(1968, 06, 22),
                Sex = 'F',
                HomeAdress = "2 Warren Street",
                PhoneNumber = "387-866-1399"
            };

            // Set up the mock repository behavior
            var mockRepository = new Mock<IPatientRepository>();
            mockRepository.Setup(m => m.GetPatientById(patientId)).ReturnsAsync(existingPatient);
            mockRepository.Setup(repo => repo.UpdatePatient(updatedPatient)).ReturnsAsync(true);
            var controller = new PatientsController(mockRepository.Object);

            // ACT
            var result = await controller.PutAsync(patientId, updatedPatient);

            // ASSERT
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PutAsync_ShouldReturnNotFound_WhenPatientDoesNotExist()
        {
            // ARRANGE
            int patientId = 11;
            var nonExistingPatient = new Patient
            {
                Id = patientId,
                FirstName = "Price",
                LastName = "Dana",
                DateOfBirth = new DateTime(1978, 08, 12),
                Sex = 'F',
                HomeAdress = "22 America blvd",
                PhoneNumber = "547-963-2577"
            };

            // Set up the mock repository behavior
            var mockRepository = new Mock<IPatientRepository>();
            mockRepository.Setup(repo => repo.GetPatientById(patientId)).ReturnsAsync((Patient)null);
            var controller = new PatientsController(mockRepository.Object);

            // ACT
            var result = await controller.PutAsync(patientId, nonExistingPatient);

            // ASSERT
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PostAsync_ShouldReturnNoContent_WhenPatientCreated()
        {
            // ARRANGE
            var patient = new Patient
            {
                FirstName = "Darth",
                LastName = "Vador",
                DateOfBirth = new DateTime(1955, 05, 31),
                Sex = 'M',
                HomeAdress = "2 Black Star avenue",
                PhoneNumber = "666-666-6666"
            };

            // Set up the mock repository and controller
            var mockRepository = new Mock<IPatientRepository>();
            var controller = new PatientsController(mockRepository.Object);

            // ACT
            var result = await controller.PostAsync(patient);

            // ASSERT
            Assert.IsType<NoContentResult>(result);

            mockRepository.Verify(repo => repo.CreatePatient(It.Is<Patient>(p =>
                p.FirstName == patient.FirstName &&
                p.LastName == patient.LastName
            )), Times.Once);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnOk_WhenPatientDeleted()
        {
            // ARRANGE
            int patientId = 11;
            var ExistingPatient = new Patient
            {
                Id = patientId,
                FirstName = "Jenny",
                LastName = "Garth",
                DateOfBirth = new DateTime(1981, 05, 03),
                Sex = 'F',
                HomeAdress = "118 Mississippi Ave",
                PhoneNumber = "645-744-0694"
            };

            // Set up the mock repository behavior
            var mockRepository = new Mock<IPatientRepository>();
            mockRepository.Setup(repo => repo.GetPatientById(patientId)).ReturnsAsync(ExistingPatient);
            var controller = new PatientsController(mockRepository.Object);

            // ACT
            var result = await controller.DeleteAsync(patientId);

            // ASSERT
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
