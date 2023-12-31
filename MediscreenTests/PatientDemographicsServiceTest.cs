using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatientDemographicsService.Models;
using PatientDemographicsService.Repositories;

namespace MediscreenTests
{
    public class PatientDemographicsServiceTest
    {
        [Fact]
        public async void TestGetAllPatients()
        {
            // Create a connection to the SQL SERVER database
            var connection = new ConnectionClass();
            using (var context = connection.CreateContextSQlDatabase())
            {

                // ARRANGE
                // There is no need to create patient in order to test the GetAllPatients() method as
                // The database should automatically be seeded with 10 patients when the solution builds

                // ACT
                // Recover all Patients from the database
                var patientRepository = new PatientRepository(context);
                var result = patientRepository.GetAllPatients();

                // ASSERT
                // Test that all the patients are persistently saved inside the SQL SERVER database
                //NB : because TestDeletePatientFromDatabase remove the patient with id = 10,
                //we need to restart the application each time we need to run this test, otherwise the last Assert will fail.
                Assert.NotEmpty(result.Result);
                Assert.IsType<List<Patient>>(result.Result);
                Assert.Collection(result.Result, item => Assert.Contains("Ferguson", item.LastName),
                                                 item => Assert.Contains("Rees", item.LastName),
                                                 item => Assert.Contains("Arnold", item.LastName),
                                                 item => Assert.Contains("Sharp", item.LastName),
                                                 item => Assert.Contains("Ince", item.LastName),
                                                 item => Assert.Contains("Ross", item.LastName),
                                                 item => Assert.Contains("Wilson", item.LastName),
                                                 item => Assert.Contains("Buckland", item.LastName),
                                                 item => Assert.Contains("Clark", item.LastName),
                                                 item => Assert.Contains("Bailey", item.LastName)
                                                 );
            }
        }

        [Fact]
        public async void TestGetPatientById()
        {
            // Create a connection to the SQL SERVER database
            var connection = new ConnectionClass();
            using (var context = connection.CreateContextSQlDatabase())
            {

                // ARRANGE
                // There is no need to create patient in order to test the GetAllPatients() method as
                // The database should automatically be seeded with 10 patients when the solution builds

                // ACT
                // Recover a single Patient from the database, by its id
                var patientRepository = new PatientRepository(context);
                var result = patientRepository.GetPatientById(1);

                // ASSERT
                // Test that a specified patient is persistently saved inside the SQL SERVER database and can be recovered
                Assert.NotNull(result.Result);
                Assert.IsType<Patient>(result.Result);
                Assert.Equal("Ferguson", result.Result.LastName);             
            }
        }

        [Fact]
        public async void TestPUTPatientToDatabase()
        {
            // Create a connection to the SQL SERVER database
            var connection = new ConnectionClass();
            using (var context = connection.CreateContextSQlDatabase())
            {
                //ARRANGE
                // There is no need to create patient in order to test the GetAllPatients() method as
                // The database should automatically be seeded with 10 patients when the solution builds

                // ACT
                //Create the SQL SERVER database and Get a Patient by its id
                var patientRepository = new PatientRepository(context);
                var patientToUpdate = await patientRepository.GetPatientById(1);

                // modify the patient
                patientToUpdate.LastName = "Doe";

                // Update the Patient in the database
                await patientRepository.UpdatePatient(patientToUpdate);

                // Recover the updated Patient from the database
                var result = await patientRepository.GetPatientById(1);

                // ASSERT
                // Test that the Patient was created inside the SQL SERVER database
                Assert.Equal("Doe", result.LastName);
            }
        }

        [Fact]
        public async void TestPOSTPatientToDatabase()
        {
            // Create a connection to the SQL SERVER database
            var connection = new ConnectionClass();
            using (var context = connection.CreateContextSQlDatabase())
            {
                //ARRANGE
                // Create a new Patient
                var patient = new Patient
                {
                    FirstName = "Sarah",
                    LastName = "Connor",
                    DateOfBirth = new DateTime(1976, 11, 14),
                    Sex = 'F',
                    HomeAdress = "45 Madison Avenue",
                    PhoneNumber = "604 544 6812"
                };

                // ACT
                //Create the SQL SERVER database and save the new Patient inside of it
                var patientRepository = new PatientRepository(context);
                await patientRepository.CreatePatient(patient);

                // Recover the created Patient from the database
                var result = await patientRepository.GetPatientById(patient.Id);

                // ASSERT
                // Test that the Patient was created inside the SQL SERVER database
                Assert.NotNull(result);
                Assert.Equal(result.LastName, "Connor");
            }
        }

        [Fact]
        public async void TestDELETEPatientFromDatabase()
        {
            // Create a connection to the SQL SERVER database
            var connection = new ConnectionClass();
            using (var context = connection.CreateContextSQlDatabase())
            {
                // ARRANGE
                //ARRANGE
                // There is no need to create patient in order to test the DeletePatient() method as
                // The database should automatically be seeded with 10 patients when the solution builds (with id = 1 to 10)

                //Create the SQL SERVER database and save the new Patient inside of it
                var patientRepository = new PatientRepository(context);

                // ACT
                // Remove the Patient with id = 10 from the database
                await patientRepository.DeletePatient(10);

                // Try to retrieve the deleted patient
                var result = await patientRepository.GetPatientById(10);

                // ASSERT
                Assert.Null(result);
            }
        }

        //Add a class containing the methods that create the connections
        //this class implement the IDisposable interface to free unmanaged resources (= close the connection) at the end of each test
        public class ConnectionClass : IDisposable
        {
            //indicate that the Dispose() method has already been run to prevent it from running while we create the connections
            private bool disposedValue;

            // create sql server connection context 
            public MediscreenDbContext CreateContextSQlDatabase()
            {
                var provider = new ServiceCollection().AddEntityFrameworkSqlServer().BuildServiceProvider();
                var builder = new DbContextOptionsBuilder<MediscreenDbContext>();
                builder.UseSqlServer($"Server=192.168.1.227,1433;Database=MediscreenPatientsTest1;User=sa;Password=P@ssword1;Encrypt=False;").UseInternalServiceProvider(provider);
                var context = new MediscreenDbContext(builder.Options);
                if (context != null)
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
                return context;
            }

            //Add a Dispose() method to close the connection when the test is over and free resources
            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects)
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                    // TODO: set large fields to null
                    disposedValue = true;
                }
            }

            public void Dispose()
            {
                // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
        }
    }
}