using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.User;
using Weelo.Core.Entities;
using Weelo.Core.Identity;
using Xunit;

namespace Tests.Endpoints.UserEndpoint
{
    public class Create : IClassFixture<ApiTestFixture>
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
        public Create(ApiTestFixture factory)
        {
            Client = factory.CreateClient();
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public HttpClient Client { get; }

        // const user to create
        private readonly string _name = "Kike";
        private readonly string _lastName = "Morales";
        private readonly string _password = "password";
        private readonly string _userName = "kike";

        [Fact]
        public async Task ReturnCreatedUsersWithoutAuthentication()
        {
            var ownerValidJson = GetValidUserJson();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "INVALID_TOKEN");
            var response = await Client.PostAsync("api/create-user", ownerValidJson);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task ReturnCreatedUsersWithAuthentication()
        {
            var ownerValidJson = GetValidUserJson();
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var claims = new TokenClaims(config);
            var token = await claims.GetTokenAsync(new User());
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await Client.PostAsync("api/create-user", ownerValidJson);

            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<CreateUserResponse>(stringResponse, _serializerSettings);

            Assert.Equal(_name, model.UserDto.Name);
            Assert.Equal(_lastName, model.UserDto.LastName);
            Assert.Equal(_userName, model.UserDto.UserName);
            Assert.Equal(_password, model.UserDto.Password);
        }

        /// <summary>
        /// Object validated test
        /// </summary>
        /// <returns>Json Owner</returns>
        private StringContent GetValidUserJson()
        {
            var request = new User
            {

                Name = _name,
                LastName = _lastName,
                UserName = _userName,
                Password = _password,
                CreatedBy = Guid.NewGuid(),
                CreatedOn = DateTime.Now

            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            return jsonContent;
        }

    }
}
