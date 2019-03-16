using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbumTechShowcase;

namespace TestPhotoAlbumTechShowcase.Tests
{
    [TestClass]
    public class PhotoAlbumApiTests
    {
        const int VALID_ID = 2;
        const int INVALID_ID = -2;

        PhotoAlbumApiService apiService = new PhotoAlbumApiService();
        [TestMethod]
        public void GetPhotosByAlbumId_ReturnsRecordsOnValidId()
        {
            var photos = apiService.GetPhotosByAlbumId(VALID_ID);
            Assert.IsNotNull(photos);
            Assert.IsTrue(photos.Any());
            Assert.IsTrue(photos.All(x => x.AlbumId == VALID_ID));
            Assert.IsTrue(photos.All(x => x.Title != string.Empty));

            //Wouldn't check for specific values if possibility of changing data
            Assert.IsTrue(photos[0].Id == 51);
            Assert.IsTrue(photos[0].Title == "non sunt voluptatem placeat consequuntur rem incidunt");
            Assert.IsTrue(photos[1].Id == 52);
            Assert.IsTrue(photos[1].Title == "eveniet pariatur quia nobis reiciendis laboriosam ea");
        }

        [TestMethod]
        public void GetPhotosByAlbumId_ReturnsEmptyListOnInvalidId()
        {
            var photos = apiService.GetPhotosByAlbumId(INVALID_ID);
            Assert.IsNotNull(photos);
            Assert.IsTrue(!photos.Any());
        }
    }
}
