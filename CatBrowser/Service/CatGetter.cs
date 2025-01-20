﻿using CatBrowser.Model;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CatBrowser.Service
{
    public class CatGetter
    {
        public List<CatImage> CatImages = new List<CatImage>();

        HttpClient Client;

        string baseUrl = "https://api.thecatapi.com/v1/images/search?limit=10&has_breeds=1";

        int pageSize = 10;

        public CatGetter ()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("x-api-key", "live_9hWnT76L1YlYgo92R1wPJEBxQPcmXu7udjk4KVyTA83mtXKaTMJkMo9WX6GLzD9s");
        }

        public async Task<List<CatImage>> GetCatImages(int page = 1)
        {
            string url = $"{baseUrl}?limit={pageSize}&page={page}&has_breeds=1";
            HttpResponseMessage response = await Client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                CatImages = await response.Content.ReadFromJsonAsync<List<CatImage>>();
            }

            return CatImages;
        }
    }
}
