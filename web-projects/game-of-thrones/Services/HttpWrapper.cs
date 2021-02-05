using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using GameOfThrones.Models;
using System.IO;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace GameOfThrones.Services
{
    public class HttpWrapper
    {
        HttpClient httpClient;
        AppRuntimeSettings runtimeSettings;

        public HttpWrapper(HttpClient httpClient, IOptions<AppRuntimeSettings> options)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            runtimeSettings = options.Value;
        }

        Uri GetPath(string fragment)
        {
            var baseUri = new Uri(runtimeSettings.ApiBaseUrl);
            var endpoint = new Uri(baseUri, fragment);

            return endpoint;
        }

        public async  Task<T> GetAsync<T>(string relativePath)
        {
            AppendHeaders();
            Uri uri = GetPath(relativePath);
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }

        void AppendHeaders()
        {
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.anapioficeandfire+json; version=1");
        }

        public async Task<T> GetAbsoluteUrlAsync<T>(string absoluteUrl)
        {
            AppendHeaders();
            Uri uri = new Uri(absoluteUrl);
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
