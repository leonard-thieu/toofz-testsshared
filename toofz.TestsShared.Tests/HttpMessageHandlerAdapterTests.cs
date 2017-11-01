using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace toofz.TestsShared.Tests
{
    public class HttpMessageHandlerAdapterTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange
                var innerHandler = new MockHttpMessageHandler();

                // Act
                var handler = new HttpMessageHandlerAdapter(innerHandler);

                // Assert
                Assert.IsType<HttpMessageHandlerAdapter>(handler);
            }
        }

        public class PublicSendAsync
        {
            [Fact]
            public async Task RequestIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var innerHandler = new MockHttpMessageHandler();
                var handler = new HttpMessageHandlerAdapter(innerHandler);
                HttpRequestMessage request = null;

                // Act -> Assert
                await Assert.ThrowsAsync<ArgumentNullException>(() =>
                {
                    return handler.PublicSendAsync(request);
                });
            }

            [Fact]
            public async Task CallsSendAsyncOnInnerHandler()
            {
                // Arrange
                var innerHandler = new MockHttpMessageHandler();
                var handler = new HttpMessageHandlerAdapter(innerHandler);
                HttpRequestMessage request = new HttpRequestMessage();

                // Act
                await handler.PublicSendAsync(request);

                // Assert
                Assert.True(innerHandler.SendAsyncCalled);
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
