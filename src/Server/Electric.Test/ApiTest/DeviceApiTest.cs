using CommonShare.Enums;
using Electric.Application.Responses;
using Electric.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Electric.Test.ApiTest
{
    public class DeviceApiTest : TestServerBase
    {
        [Fact]
        public async Task GetAllElectric_ReturnOK()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.apiUrl);

                var responseBody = await response.Content.ReadAsStringAsync();
                var electrics = JsonConvert.DeserializeObject<IEnumerable<DeviceResponse>>(responseBody);

                // Assert
                Assert.NotEmpty(electrics);
            }
        }

        [Fact]
        public async Task GetElectricById_ReturnOK()
        {
            using (var server = CreateServer())
            {
                string id = "5f41ef43c7701c8c9e538986";
                var response = await server.CreateClient()
                    .GetAsync(Get.DeviceBy(id));

                var responseBody = await response.Content.ReadAsStringAsync();
                var electric = JsonConvert.DeserializeObject<DeviceResponse>(responseBody);

                // Assert
                Assert.NotNull(electric);
            }
        }

        [Fact]
        public async Task CreateElectric_ReturnOK()
        {
            using (var server = CreateServer())
            {
                string serialNumber = Guid.NewGuid().ToString();
                var content = new StringContent(BuildElectricRequest(serialNumber), UTF8Encoding.UTF8, "application/json");
                var response = await server.CreateClient()
                    .PostAsync(Post.apiUrl, content);

                var responseBody = await response.Content.ReadAsStringAsync();
               
                var id = responseBody;

                var getElectricRespone = await server.CreateClient()
                   .GetAsync(Get.DeviceBy(id));

                var getElectricBody = await getElectricRespone.Content.ReadAsStringAsync();

                var electric = JsonConvert.DeserializeObject<DeviceResponse>(getElectricBody);

                // Assert
                Assert.NotNull(electric);
                Assert.Equal(electric.SeriaNumber, serialNumber);
            }
        }

        private string BuildElectricRequest(string seriaNumber)
        {
            var electric = new Device
            {
                FirmwareVersion = "3434",
                SeriaNumber = seriaNumber,
                GateWay = new GateWay
                {
                    IP = "192.55.55.5",
                    Port = 2222,
                },
                State = "New",
                Type = (int)ElectricType.GateWay
            };

            return JsonConvert.SerializeObject(electric);
        }
    }
}
