using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;

namespace toofz.TestsShared.Tests
{
    class MockedRequestExtensionsTests
    {
        [TestClass]
        public class RespondJson_Object_Method
        {
            [TestMethod]
            public void SourceIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                MockedRequest source = null;
                object content = new object();

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    MockedRequestExtensions.RespondJson(source, content);
                });
            }

            [TestMethod]
            public async Task RespondsWithApplicationJsonMediaType()
            {
                // Arrange
                MockedRequest source = new MockedRequest();
                object content = new
                {
                    myProp = "myProperty",
                };

                // Act
                MockedRequestExtensions.RespondJson(source, content);
                var response = await source.SendAsync(new HttpRequestMessage(), CancellationToken.None);
                var mediaType = response.Content.Headers.ContentType.MediaType;

                // Assert
                Assert.AreEqual("application/json", mediaType);
            }

            [TestMethod]
            public async Task RespondsWithJson()
            {
                // Arrange
                MockedRequest source = new MockedRequest();
                object content = new
                {
                    myProp = "myProperty",
                };

                // Act
                MockedRequestExtensions.RespondJson(source, content);
                var response = await source.SendAsync(new HttpRequestMessage(), CancellationToken.None);
                var json = await response.Content.ReadAsStringAsync();

                // Assert
                Assert.AreEqual("{\"myProp\":\"myProperty\"}", json);
            }
        }

        [TestClass]
        public class RespondJson_String_Method
        {
            [TestMethod]
            public void SourceIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                MockedRequest source = null;
                string content = "myContent";

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    MockedRequestExtensions.RespondJson(source, content);
                });
            }

            [TestMethod]
            public async Task RespondsWithApplicationJsonMediaType()
            {
                // Arrange
                MockedRequest source = new MockedRequest();
                string content = "{\"myProp\":\"myProperty\"}";

                // Act
                MockedRequestExtensions.RespondJson(source, content);
                var response = await source.SendAsync(new HttpRequestMessage(), CancellationToken.None);
                var mediaType = response.Content.Headers.ContentType.MediaType;

                // Assert
                Assert.AreEqual("application/json", mediaType);
            }

            [TestMethod]
            public async Task RespondsWithJson()
            {
                // Arrange
                MockedRequest source = new MockedRequest();
                string content = "{\"myProp\":\"myProperty\"}";

                // Act
                MockedRequestExtensions.RespondJson(source, content);
                var response = await source.SendAsync(new HttpRequestMessage(), CancellationToken.None);
                var json = await response.Content.ReadAsStringAsync();

                // Assert
                Assert.AreEqual("{\"myProp\":\"myProperty\"}", json);
            }
        }
    }
}
