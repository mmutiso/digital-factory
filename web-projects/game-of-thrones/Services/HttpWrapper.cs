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
using Microsoft.Extensions.Logging;

namespace GameOfThrones.Services
{
    public class HttpWrapper
    {
        HttpClient httpClient;
        AppRuntimeSettings runtimeSettings;
        ILogger<HttpWrapper> logger;

        public HttpWrapper(HttpClient httpClient, IOptions<AppRuntimeSettings> options, 
            ILogger<HttpWrapper> logger)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            runtimeSettings = options.Value;
            this.logger = logger;
        }

        Uri GetPath(string fragment, int page)
        {
            var baseUri = new Uri(runtimeSettings.ApiBaseUrl);
            if (page > 0)
            {
                var endpoint = new Uri(baseUri, $"{fragment}?page={page}");
                return endpoint;
            }
            else
            {
                var endpoint = new Uri(baseUri, fragment);
                return endpoint;
            }   
        }

        public async  Task<ApiResponse<T>> GetAsync<T>(string relativePath, int page)
        {
            AppendHeaders();
            Uri uri = GetPath(relativePath, page);
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var linkHeaders =  response.Headers.GetValues("Link");          
            
            string responseBody = await response.Content.ReadAsStringAsync();

            T obj = JsonConvert.DeserializeObject<T>(responseBody);

            return new ApiResponse<T> { HttpResponse = obj, LinkHeader = linkHeaders.FirstOrDefault() };
        }
        public async Task<T> GetAsync<T>(string relativePath)
        {
            AppendHeaders();
            Uri uri = GetPath(relativePath, 0);
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }

        void AppendHeaders()
        {
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.anapioficeandfire+json; version=1");
        }

        public async Task<T> GetAbsoluteUrlAsync<T>(string absoluteUrl, int page)
        {
            AppendHeaders();
            Uri uri = new Uri($"{absoluteUrl}?page={page}");
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
