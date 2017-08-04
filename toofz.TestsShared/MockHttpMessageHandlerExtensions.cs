using System;
using RichardSzalay.MockHttp;

namespace toofz.TestsShared
{
    public static class MockHttpMessageHandlerExtensions
    {
        public static MockedRequest When(this MockHttpMessageHandler handler, Uri uri)
        {
            return handler.When(uri.ToString());
        }

        public static MockedRequest Expect(this MockHttpMessageHandler handler, Uri uri)
        {
            return handler.Expect(uri.ToString());
        }
    }
}
