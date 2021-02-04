using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using GameOfThrones.Models;
using System.IO;

namespace GameOfThrones.Services
{
    public class HttpWrapper
    {
        HttpClient httpClient;
        AppRuntimeSettings runtimeSettings;

        public HttpWrapper(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        Uri GetPath(string fragment)
        {
            var baseUri = new Uri(runtimeSettings.ApiBaseUrl);
            var endpoint = new Uri(baseUri, fragment);

            return endpoint;
        }

        public async  Task<T> Get<T>(string relativePath)
        {
            Uri uri = GetPath(relativePath);
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
