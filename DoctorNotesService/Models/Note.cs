using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DoctorNotesService.Models
{
    [BsonIgnoreExtraElements]
    public class Note
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("patientid")]
        [BsonRepresentation(BsonType.Int32)]
        public int PatientId { get; set; }

        [BsonElement("doctorid")]
        [BsonRepresentation(BsonType.Int32)]
        public int DoctorId { get; set; }

        [BsonElement("notecontent")]
        public string NoteContent { get; set; } = string.Empty;
    }
}
