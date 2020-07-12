using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace OpenAPIRonnies.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public async Task CRUD_test_suite()
        {
            var hostUrl = "http://localhost:5000";
            using (var testServer = new TestServer(Program.CreateWebHostBuilder(new string[0])))
            {
                using (var httpClient = testServer.CreateClient())
                {
                    var client = new Client(hostUrl, httpClient);

                    var ronny = new CreateOrUpdateRonny
                    {
                        Name = "Some Test Name",
                        Price = 7
                    };

                    var createResponse = await client.CreateRonnyAsync(ronny);

                    var updateRonny = new CreateOrUpdateRonny
                    {
                        Name = "Updated Test Name",
                        Price = 9
                    };

                    await client.UpdateRonnyAsync(updateRonny, createResponse.Id);

                    var result = await httpClient.GetAsync($"{hostUrl}/ronnies?$filter=Name eq 'Updated Test Name'");
                    var odataResponse =
                        await result
                            .Content
                            .ReadAsStringAsync()
                            .ContinueWith(t => JsonConvert.DeserializeObject<ODataResponse>(t.Result));

                    Assert.Equal(1, odataResponse.Value.Count);

                    await client.DeleteRonnyAsync(createResponse.Id);
                }
            }
        }
    }
}