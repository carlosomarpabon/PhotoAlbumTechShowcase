using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbumTechShowcase;

namespace TestPhotoAlbumTechShowcase.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void GetPhotosByAlbumId_ReturnsRecordsOnValidId()
        {
            var photos = Program.GetPhotosByAlbumId(2);
            Assert.IsNotNull(photos);
            Assert.IsTrue(photos.Any());
        }

        [TestMethod]
        public void GetPhotosByAlbumId_ReturnEmptyListOnInvalidId()
        {
            var photos = Program.GetPhotosByAlbumId(-2);
            Assert.IsNotNull(photos);
            Assert.IsTrue(!photos.Any());
        }
    }
}
