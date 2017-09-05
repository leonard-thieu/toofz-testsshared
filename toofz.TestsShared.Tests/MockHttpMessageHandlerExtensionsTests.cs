using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;

namespace toofz.TestsShared.Tests
{
    class MockHttpMessageHandlerExtensionsTests
    {
        [TestClass]
        public class WhenMethod
        {
            [TestMethod]
            public void HandlerIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                MockHttpMessageHandler handler = null;
                Uri uri = new Uri("http://example.org/");

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    MockHttpMessageHandlerExtensions.When(handler, uri);
                });
            }

            [TestMethod]
            public void UriIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                MockHttpMessageHandler handler = new MockHttpMessageHandler();
                Uri uri = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    MockHttpMessageHandlerExtensions.When(handler, uri);
                });
            }

            [TestMethod]
            public void ReturnsMockedRequest()
            {
                // Arrange
                MockHttpMessageHandler handler = new MockHttpMessageHandler();
                Uri uri = new Uri("http://example.org/");

                // Act
                var request = MockHttpMessageHandlerExtensions.When(handler, uri);

                // Assert
                Assert.IsInstanceOfType(request, typeof(MockedRequest));
            }

            [TestMethod]
            public async Task AddsBackendDefinition()
            {
                // Arrange
                MockHttpMessageHandler handler = new MockHttpMessageHandler();
                Uri uri = new Uri("http://example.org/");
                var httpClient = handler.ToHttpClient();

                // Act
                MockHttpMessageHandlerExtensions
                                    .When(handler, uri)
                                    .Respond(new StringContent("Response from http://example.org/."));
                var response = await httpClient.GetStringAsync(uri);

                // Assert
                Assert.AreEqual("Response from http://example.org/.", response);
            }
        }

        [TestClass]
        public class ExpectMethod
        {
            [TestMethod]
            public void HandlerIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                MockHttpMessageHandler handler = null;
                Uri uri = new Uri("http://example.org/");

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    MockHttpMessageHandlerExtensions.Expect(handler, uri);
                });
            }

            [TestMethod]
            public void UriIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                MockHttpMessageHandler handler = new MockHttpMessageHandler();
                Uri uri = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    MockHttpMessageHandlerExtensions.Expect(handler, uri);
                });
            }

            [TestMethod]
            public void ReturnsMockedRequest()
            {
                // Arrange
                MockHttpMessageHandler handler = new MockHttpMessageHandler();
                Uri uri = new Uri("http://example.org/");

                // Act
                var request = MockHttpMessageHandlerExtensions.Expect(handler, uri);

                // Assert
                Assert.IsInstanceOfType(request, typeof(MockedRequest));
            }

            [TestMethod]
            public void AddsRequestExpectation()
            {
                // Arrange
                MockHttpMessageHandler handler = new MockHttpMessageHandler();
                Uri uri = new Uri("http://example.org/");
                MockHttpMessageHandlerExtensions.Expect(handler, uri);

                // Act -> Assert
                Assert.ThrowsException<InvalidOperationException>(() =>
                {
                    handler.VerifyNoOutstandingExpectation();
                });
            }
        }
    }
}
