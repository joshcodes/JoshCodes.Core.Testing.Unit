using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JoshCodes.Core.Extensions;

namespace JoshCodes.Core.Testing.Unit
{
    [TestClass]
    public class UriExtensionsTest
    {
        [TestMethod]
        public void GetFileName()
        {
            GetFileNameGeneric("bar.png", "http://example.com/foo/bar.png?food=barf");
            GetFileNameGeneric("0_480x480_F.jpg", "http://images.cafepress.com/merchandise/0_480x480_F.jpg");
            GetFileNameGeneric(null, "http://images.cafepress.com/");
            GetFileNameGeneric("0_480x480_F.jpg", "../../merchandise/0_480x480_F.jpg");
        }

        private void GetFileNameGeneric(string expectedFilename, string uriString)
        {
            var uri = new Uri(uriString);
            var filename = uri.GetFileName();
            Assert.AreEqual(expectedFilename, filename);
        }

        [TestMethod]
        public void ChangeFileExtension()
        {
            ChangeFileExtensionGeneric("jpg", "http://example.com/foo/bar.png?food=barf", "http://example.com/foo/bar.jpg?food=barf");
            ChangeFileExtensionGeneric("jpeg", "http://images.cafepress.com/merchandise/0_480x480_F.jpg", "http://images.cafepress.com/merchandise/0_480x480_F.jpeg");
            ChangeFileExtensionGeneric("png", "http://images.cafepress.com/x.png", "http://images.cafepress.com/x.png");
        }

        private void ChangeFileExtensionGeneric(string extension, string uriString, string expectedUriString)
        {
            var uri = new Uri(uriString);
            var changedUri = uri.ChangeFileExtension(extension);
            Assert.AreEqual(expectedUriString, changedUri.AbsoluteUri);
        }
    }
}
