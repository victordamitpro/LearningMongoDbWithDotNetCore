using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Electric.Core.Entities
{
    public class Device
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string SeriaNumber { get; set; }
        [BsonRequired]
        public string FirmwareVersion { get; set; }

        public string State { get; set; }

        public int Type { get; set; }

        public GateWay GateWay { get; set; }

        public Device()
        {
            GateWay = new GateWay();
        }

        public static Device Create(Device device)
        {
            return new Device
            {
                Id = device.Id,
                SeriaNumber = device.SeriaNumber,
                FirmwareVersion = device.FirmwareVersion,
                State = device.State,
                GateWay = new GateWay {
                    IP = device.GateWay.IP,
                    Port = device.GateWay.Port,
                },
                Type = device.Type
            };
        }

        public static Device New()
        {
            return new Device();
        }
    }
}
