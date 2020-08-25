using CommonShare.Enums;
using Electric.Core.Entities;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Electric.Infrastructure.Data
{
    public class ElectricContextSeedData
    {
        public static void SeedData(IMongoCollection<Device> electricCollection)
        {
            bool existElectric = electricCollection.Find(p => true).Any();
            if (!existElectric)
            {
                electricCollection.InsertManyAsync(GetDefaultElectric());
            }
        }

        private static IEnumerable<Device> GetDefaultElectric()
        {
            return new List<Device>()
            {
                new Device()
                {
                    SeriaNumber = "1ADSFS",
                    FirmwareVersion = "1.0",
                    State ="New",
                    Type = (int)ElectricType.Electric,
                    GateWay = new GateWay
                    {
                        Port = 2222,
                        IP = "123.22.33.3"
                    }
                },
                new Device()
                {
                    SeriaNumber = "234DSFSD",
                    FirmwareVersion = "2.0",
                    State = "New",
                    Type = (int)ElectricType.GateWay,
                    GateWay = new GateWay
                    {
                        Port = 2222,
                        IP = "123.22.33.3"
                    }
                }
            };
        }
    }
}
