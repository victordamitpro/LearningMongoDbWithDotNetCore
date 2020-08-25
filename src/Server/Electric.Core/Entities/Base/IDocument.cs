using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Electric.Core.Entities.Base
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
        DateTime CreatedAt { get; }
        string SeriaNumber { get; set; }
        string FirmwareVersion { get; set; }
        string State { get; set; }
    }
}
