using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
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
            var result = await controller.GetAsync();

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
            var result = await controller.GetByIdAsync(patientId);

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
            var result = await controller.GetByIdAsync(patientId);

            // ASSERT
            var objectResult = Assert.IsType<ActionResult<Patient>>(result);
            Assert.Null(objectResult.Value);
        }
    }
}
