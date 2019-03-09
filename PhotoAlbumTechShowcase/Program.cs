using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;

namespace PhotoAlbumTechShowcase
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Photo Album Service.");
            while (true)
            {
                var inputAlbumId = GetInputAlbumId();
                var photos = GetPhotosByAlbumId(inputAlbumId);

                foreach (var p in photos)
                {
                    Console.WriteLine($"[{p.Id}] {p.Title}");
                }
            }
        }
        public static List<Photo> GetPhotosByAlbumId(int albumId)
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

        /// <summary>
        /// The Console commands in this method could be moved into Main to allow the rest of this method to be tested.
        /// But then what would we test, int.TryParse? I believe this untestable method makes the app cleaner. :)
        /// </summary>
        /// <returns></returns>
        private static int GetInputAlbumId()
        {
            int? desiredAlbumId = null;
            while (desiredAlbumId == null)
            {
                Console.WriteLine("photo-album");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int temp))
                {
                    desiredAlbumId = temp;
                }
                else
                {
                    Console.WriteLine("Photo Album Ids can only be numbers.");
                }
            }
            return (int)desiredAlbumId;
        }
    }
}
