using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace PhotoAlbumTechShowcase
{
    public class PhotoAlbumApiService
    {
        public List<Photo> GetPhotosByAlbumId(int albumId)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com/photos")
            };
            using (httpClient)
            {
                var getTask = httpClient.GetStringAsync($"{httpClient.BaseAddress}?albumId={albumId}");
                getTask.Wait();
                var result = getTask.Result;
                return JsonConvert.DeserializeObject<List<Photo>>(result);
            }
        }
    }
}
