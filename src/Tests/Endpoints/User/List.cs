using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.User;
using Weelo.Core.Dtos;
using Weelo.Core.Entities;
using Weelo.Core.Identity;
using Xunit;

namespace Tests.Endpoints.UserEndpoint
{
    public class List : IClassFixture<ApiTestFixture>
    {
        /// <summary>
        /// Configuracion de json 
        /// </summary>
        readonly JsonSerializerSettings _serializerSettings = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            NullValueHandling = NullValueHandling.Ignore,
        };

        /// <summary>
        /// Constructor OwnerEndpoint
        /// </summary>
        /// <param name="factory"></param>
        public List(ApiTestFixture factory)
        {
            Client = factory.CreateClient();
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnListUserWithoutAuthentication()
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "INVALID_TOKEN");
            var response = await Client.GetAsync("api/list-owners");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task ReturnListUserWithAuthentication()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var claims = new TokenClaims(config);
            var token = await claims.GetTokenAsync(new User());
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await Client.GetAsync("api/list-owners");

            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<ListUserResponse>(stringResponse, _serializerSettings);

            Assert.IsType<List<UserDto>>(model.Users);
        }


    }
}
