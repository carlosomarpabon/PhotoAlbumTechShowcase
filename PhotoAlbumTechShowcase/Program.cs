using System;

namespace PhotoAlbumTechShowcase
{
    public class Program
    {
        static void Main()
        {
            var apiService = new PhotoAlbumApiService();
            Console.WriteLine("Photo Album Service.");
            while (true)
            {
                var inputAlbumId = GetInputAlbumId();
                var photos = apiService.GetPhotosByAlbumId(inputAlbumId);

                foreach (var p in photos)
                {
                    Console.WriteLine($"[{p.Id}] {p.Title}");
                }
            }
        }

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
