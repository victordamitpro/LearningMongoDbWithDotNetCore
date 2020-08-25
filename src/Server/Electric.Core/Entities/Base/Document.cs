using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Electric.Core.Entities.Base
{
    public abstract class Document : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime CreatedAt => DateTime.Now;

        [BsonRequired]
        public string SeriaNumber { get; set; }
        [BsonRequired]
        public string FirmwareVersion { get; set; }

        public string State { get; set; }
    }
}
