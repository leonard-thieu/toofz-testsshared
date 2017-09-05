using System;
using RichardSzalay.MockHttp;

namespace toofz.TestsShared
{
    /// <summary>
    /// Provides extension methods for <see cref="MockHttpMessageHandler"/>.
    /// </summary>
    public static class MockHttpMessageHandlerExtensions
    {
        /// <summary>
        /// Adds a backend definition.
        /// </summary>
        /// <param name="handler">The source handler.</param>
        /// <param name="uri">The URL to match.</param>
        /// <returns>The <see cref="MockedRequest"/> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="handler"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="uri"/> is null.
        /// </exception>
        public static MockedRequest When(this MockHttpMessageHandler handler, Uri uri)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

            return handler.When(uri.ToString());
        }
        /// <summary>
        /// Adds a request expectation.
        /// </summary>
        /// <param name="handler">The source handler.</param>
        /// <param name="uri">The URL to match.</param>
        /// <returns>The <see cref="MockedRequest"/> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="handler"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="uri"/> is null.
        /// </exception>
        public static MockedRequest Expect(this MockHttpMessageHandler handler, Uri uri)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

            return handler.Expect(uri.ToString());
        }
    }
}
