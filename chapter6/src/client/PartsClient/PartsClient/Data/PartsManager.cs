using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PartsClient.Data
{
    public static class PartsManager
    {
        // TODO: Add fields for BaseAddress, Url, and authorizationKey
        /// <summary>
        /// 
        /// </summary>
        private const string BaseAddress = "https://mslearnpartsserver1047616691.azurewebsites.net";

        /// <summary>
        /// 
        /// </summary>
        private const string Url = $"{BaseAddress}/api/";

        /// <summary>
        /// 
        /// </summary>
        private static string _authorizationKey;

        /// <summary>
        /// 
        /// </summary>
        private static HttpClient _client;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static async Task<HttpClient> GetClient()
        {
            if (_client != null)
                return _client;

            _client = new HttpClient();

            if (string.IsNullOrEmpty(_authorizationKey))
            {
                _authorizationKey = await _client.GetStringAsync($"{Url}login");
                _authorizationKey = JsonConvert.DeserializeObject<string>(_authorizationKey);
            }

            _client.DefaultRequestHeaders.Add("Authorization", _authorizationKey);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");

            return _client;
        }

        public static async Task<IEnumerable<Part>> GetAll()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new List<Part>();

            HttpClient client = await GetClient();
            string result = await client.GetStringAsync($"{Url}parts");

            return JsonConvert.DeserializeObject<List<Part>>(result);
        }

        public static async Task<Part> Add(string partName, string supplier, string partType)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new Part();

            var part = new Part()
            {
                PartName = partName,
                Suppliers = new List<string>(new[]
                {
                    supplier
                }),
                PartId = string.Empty,
                PartType = partType,
                PartAvailableDate = DateTime.Now.Date
            };
            var client = await GetClient();
            var msg = new HttpRequestMessage(HttpMethod.Post, $"{Url}parts");
            msg.Content = JsonContent.Create<Part>(part);
            var response = await client.SendAsync(msg);
            response.EnsureSuccessStatusCode();

            var returnedJson = await response.Content.ReadAsStringAsync();

            var insertedPart = JsonConvert.DeserializeObject<Part>(returnedJson);
            return insertedPart;
        }

        public static async Task Update(Part part)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return;

            HttpRequestMessage msg = new(HttpMethod.Put, $"{Url}parts/{part.PartId}");
            msg.Content = JsonContent.Create<Part>(part);
            HttpClient client = await GetClient();
            var response = await client.SendAsync(msg);
            response.EnsureSuccessStatusCode();
        }

        public static async Task Delete(string partId)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return;

            HttpRequestMessage msg = new(HttpMethod.Delete, $"{Url}parts/{partId}");
            HttpClient client = await GetClient();
            var response = await client.SendAsync(msg);
            response.EnsureSuccessStatusCode();
        }
    }
}