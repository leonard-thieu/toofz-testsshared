using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace toofz.TestsShared.Tests
{
    internal class HttpMessageHandlerAdapterTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var innerHandler = new MockHttpMessageHandler();

                // Act
                var handler = new HttpMessageHandlerAdapter(innerHandler);

                // Assert
                Assert.IsInstanceOfType(handler, typeof(HttpMessageHandlerAdapter));
            }
        }

        [TestClass]
        public class PublicSendAsync
        {
            [TestMethod]
            public async Task RequestIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var innerHandler = new MockHttpMessageHandler();
                var handler = new HttpMessageHandlerAdapter(innerHandler);
                HttpRequestMessage request = null;

                // Act -> Assert
                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() =>
                {
                    return handler.PublicSendAsync(request);
                });
            }

            [TestMethod]
            public async Task CallsSendAsyncOnInnerHandler()
            {
                // Arrange
                var innerHandler = new MockHttpMessageHandler();
                var handler = new HttpMessageHandlerAdapter(innerHandler);
                HttpRequestMessage request = new HttpRequestMessage();

                // Act
                await handler.PublicSendAsync(request);

                // Assert
                Assert.IsTrue(innerHandler.SendAsyncCalled);
            }
        }

        private class MockHttpMessageHandler : HttpMessageHandler
        {
            public bool SendAsyncCalled { get; private set; }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                SendAsyncCalled = true;

                return Task.FromResult(new HttpResponseMessage());
            }
        }
    }
}
