﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Owner;
using Weelo.Core.Entities;
using Weelo.Core.Identity;
using Xunit;


namespace Tests.Endpoints.OwnerEndpoint
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

        // const owner to create
        private readonly string _name = "Pedro Morales";
        private readonly string _address = "Krr 4578 Jueves";
        private readonly DateTime _birthday = DateTime.Now;
        private readonly string _photo = "not here photo";

        [Fact]
        public async Task ReturnCreatedOwnerWithoutAuthentication()
        {
            var ownerValidJson = GetValidOwnerJson();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "INVALID_TOKEN");
            var response = await Client.PostAsync("api/create-owner", ownerValidJson);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task ReturnCreatedOwnerWithAuthentication()
        {
            var ownerValidJson = GetValidOwnerJson();
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var claims = new TokenClaims(config);
            var token = await claims.GetTokenAsync(new User() );
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await Client.PostAsync("api/create-owner", ownerValidJson);

            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<CreateOwnerResponse>(stringResponse, _serializerSettings);

            Assert.Equal(_name, model.OwnerDto.Name);
            Assert.Equal(_address, model.OwnerDto.Address);
            Assert.Equal(_photo, model.OwnerDto.Photo);
        }

        /// <summary>
        /// Object validated test
        /// </summary>
        /// <returns>Json Owner</returns>
        private StringContent GetValidOwnerJson()
        {
            var request = new Owner
            {

                Name = _name,
                Address = _address,
                Photo = _photo,
                Birthday = _birthday

            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            return jsonContent;
        }

    }
}
