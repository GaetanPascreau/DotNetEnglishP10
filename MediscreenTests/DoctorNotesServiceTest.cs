using System.Collections.Generic;
using System.Linq;
using DoctorNotesService.Models;
using DoctorNotesService.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using PatientDemographicsService.Models;
using Xunit;

namespace MediscreenTests
{
    public class DoctorNotesServiceTest
    {

        [Fact]
        public async Task GetByDoctorIdAsync_ShouldReturnCorrectNotes()
        {
            // Create a connection to the MongoDB database
            using (var connection = new ConnectionClass())
            {
                // ARRANGE
                var doctorId = 10;
                var expectedNotes = new List<Note>
            {
                new Note { DoctorId = doctorId },
                new Note { DoctorId = doctorId }
            };

                // Insert test data into the collection
                await connection.NotesCollection.InsertManyAsync(expectedNotes);

                // ACT
                var result = await connection.NoteService.GetByDoctorIdAsync(doctorId);

                // ASSERT 
                Assert.Equal(expectedNotes.Count, result.Count);
                Assert.All(result, note => Assert.Equal(doctorId, note.DoctorId));
            }        
        }

        [Fact]
        public async Task GetByPatientIdAsync_ShouldReturnCorrectNotes()
        {
            // Create a connection to the MongoDB database
            using (var connection = new ConnectionClass())
            {
                // ARRANGE
                var patientId = 12;
                var expectedNotes = new List<Note>
            {
                new Note { PatientId = patientId },
                new Note { PatientId = patientId }
            };

                // Insert test data into the collection
                await connection.NotesCollection.InsertManyAsync(expectedNotes);

                // ACT
                var result = await connection.NoteService.GetByPatientIdAsync(patientId);

                // ASSERT 
                Assert.Equal(expectedNotes.Count, result.Count);
                Assert.All(result, note => Assert.Equal(patientId, note.PatientId));
            }
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectNotes()
        {
            // Create a connection to the MongoDB database
            using (var connection = new ConnectionClass())
            {
                // ARRANGE
                var id = "D955E83A3F07F077262F8ADC";
                var expectedNote = new Note { Id = id };
           

                // Insert test data into the collection
                await connection.NotesCollection.InsertOneAsync(expectedNote);

                // ACT
                var result = await connection.NoteService.GetByIdAsync(id);

                // ASSERT 
                Assert.NotNull(result);
                Assert.Equal(expectedNote.Id, result.Id);
            }
        }

        [Fact]
        public async Task GetAsync_ShouldReturnAllNotes()
        {
            // Create a connection to the MongoDB database
            using (var connection = new ConnectionClass())
            {
                // ARRANGE
                var id1 = "8F4BF49E8DF1A19DBF7D7C82";
                var id2 = "7D5883CF4095DB2974599C57";
                var expectedNotes = new List<Note>
                {
                    new Note { Id = id1 },
                    new Note { Id = id2 }
                };


                // Insert test data into the collection
                await connection.NotesCollection.InsertManyAsync(expectedNotes);

                // ACT
                var result = await connection.NoteService.GetAsync();

                // ASSERT 
                Assert.NotNull(result);
                Assert.Equal(expectedNotes.Count, result.Count);
                for (int i = 0; i < expectedNotes.Count; i++) 
                {
                    Assert.Equal(expectedNotes[i].Id, result[i].Id);
                }
            }
        }

        [Fact]
        public async Task PutAsync_ShouldUpdateSelectedNote()
        {
            // Create a connection to the MongoDB database
            using (var connection = new ConnectionClass())
            {
                // ARRANGE
                var id = "8F4BF49E8DF1A19DBF7D7C82";

                var initialNote = new Note {
                    Id = id,
                    PatientId = 1,
                    DoctorId = 1,
                    NoteContent = "this is the note content"
                };

                // Insert test data into the collection
                await connection.NotesCollection.InsertOneAsync(initialNote);

                var updatedNote = new Note
                {
                    Id = id,
                    PatientId = 1,
                    DoctorId = 2,
                    NoteContent = "this is the new note content"
                };

                // ACT
                await connection.NoteService.UpdateAsync(id, updatedNote);

                var result = await connection.NoteService.GetByIdAsync(id);

                // ASSERT 
                Assert.NotNull(result);
                Assert.Equal(updatedNote.Id, result.Id);
                Assert.Equal(updatedNote.DoctorId, result.DoctorId);
                Assert.Equal(updatedNote.NoteContent, result.NoteContent);
                Assert.Equal(initialNote.PatientId, result.PatientId);
            }
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteNote()
        {
            using (var connection = new ConnectionClass())
            {
                // ARRANGE
                var id = "22E67B71E9889E87B5FB5FD5";
                var initialNote = new Note
                {
                    Id = id,
                    PatientId = 2,
                    DoctorId = 3,
                    NoteContent = "this is the note content"
                };
                await connection.NotesCollection.InsertOneAsync(initialNote);

                // ACT
                await connection.NoteService.RemoveAsync(id);

                // Try to retrieve the deleted note
                var result = await connection.NoteService.GetByIdAsync(id);

                // ASSERT
                Assert.Null(result); // Ensure the result is null, indicating the note was deleted
            }
        }

        public class ConnectionClass : IDisposable
        {
            private bool disposedValue;

            // Store the notes collection and note service instance
            public IMongoCollection<Note> NotesCollection { get; private set; }
            public NoteService NoteService { get; private set; }

            public ConnectionClass()
            {
                var connectionString = "mongodb://gaetanpascreau:npSaR6e4P8anvZv2@mongo:27017/MediscreenNoSql";
                //var databaseName = "MediscreenNoSql";
                var collectionName = "notes";
                var settings = new NoteStoreDatabaseSettings 
                { 
                    CollectionName = collectionName,
                    DatabaseName = "MediscreenNoSql",
                    ConnectionString = connectionString
                };

                var mongoClient = new MongoClient(connectionString);
                var database = mongoClient.GetDatabase(settings.DatabaseName);
                database.CreateCollection(collectionName);
                NotesCollection = database.GetCollection<Note>(collectionName);
                NoteService = new NoteService(settings, mongoClient); 
            }

            //Add a Dispose() method to close the connection when the test is over and free resources
            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // Drop the collection to clean up test data
                        NotesCollection.Database.DropCollection(NotesCollection.CollectionNamespace.CollectionName);
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



    //Add a class containing the methods that create the connections
    //this class implement the IDisposable interface to free unmanaged resources (= close the connection) at the end of each test
    //public class ConnectionClass : IDisposable
    //{
    //    //indicate that the Dispose() method has already been run to prevent it from running while we create the connections
    //    private bool disposedValue;

    //    public ConnectionClass()
    //    {
    //        var config = new ConfigurationBuilder()
    //            .AddJsonFile("appsettings.json")
    //            .Build();

    //        var connString = config.GetConnectionString("db");

    //        var dbName = $"test_db_{Guid.NewGuid()}";

    //        this.DbContextSettings = new MongoDbContextSettings(connString, dbName);

    //        this.DbContext = new MongoDbContext(this.DbContextSettings);
    //    }

    //    public MongoDbContextSettings DbContextSettings { get; }

    //    public MongoDbContext DbContext { get; }

    //    public void Dispose()
    //    {
    //        var client = new MongoClient(this.DbContextSettings.ConnectionString);

    //        client.DropDatabase(this.DbContextSettings.DatabaseName);
    //    }
    //}

    //public class Mongo2GoFixture : IDisposable
    //{
    //    public MongoClient Client { get; }

    //    public IMongoDatabase Database { get; }

    //    public string ConnectionString { get; }

    //    private readonly MongoDbRunner _mongoRunner;

    //    private readonly string _databaseName = "my-database";

    //    public IMongoCollection<Note> DataBoundCollection { get; }

    //    public Mongo2GoFixture()
    //    {
    //        // initializes the instance
    //        _mongoRunner = MongoDbRunner.Start();

    //        // store the connection string with the chosen port number
    //        ConnectionString = _mongoRunner.ConnectionString;

    //        // create a client and database for use outside the class
    //        Client = new MongoClient(ConnectionString);

    //        Database = Client.GetDatabase(_databaseName);

    //        // initialize your collection
    //        DataBoundCollection = Database.GetCollection<Note>("databoundobject");
    //    }

    //    public void SeedData(string file)
    //    {
    //        var documentCount = DataBoundCollection.CountDocuments(Builders<Note>.Filter.Empty);
    //        if (documentCount == 0)
    //        {
    //            _mongoRunner.Import(_databaseName, "databoundobject", GetFilePath(file), true);
    //        }
    //    }

    //    // GetFilePath using DockerFixture's approach
    //    private string GetFilePath(string file)
    //    {
    //        // resolve file-path here
    //    }

    //    public void Dispose()
    //    {
    //        _mongoRunner.Dispose();
    //    }
    //}
}