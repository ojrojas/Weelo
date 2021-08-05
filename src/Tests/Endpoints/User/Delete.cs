using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
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
    public class Delete : IClassFixture<ApiTestFixture>
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
        public Delete(ApiTestFixture factory)
        {
            Client = factory.CreateClient();
            Client2 = factory.CreateClient();
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public HttpClient Client { get; }
        public HttpClient Client2 { get; }

        // const user to create
        private readonly string _name = "Maria";
        private readonly string _lastName = "Garces";
        private readonly string _password = "password";
        private readonly string _userName = "maria";

        [Fact]
        public async Task ReturnDeleteUserWithoutAuthentication()
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "INVALID_TOKEN");
            var response = await Client.DeleteAsync("api/delete-user/" + Guid.NewGuid());

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task ReturnDeleteUserWithAuthentication()
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

            var deleteUrl = "api/delete-user/" + model.UserDto.Id;

            var token2 = await claims.GetTokenAsync(new User());
            Client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token2);
            var response2 = await Client2.DeleteAsync(deleteUrl);
            response2.EnsureSuccessStatusCode();
            var stringResponse2 = await response2.Content.ReadAsStringAsync();
            var model2 = JsonConvert.DeserializeObject<DeleteUserResponse>(stringResponse2, _serializerSettings);


            Assert.Equal(model2.UserDto.Id, model.UserDto.Id);
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
