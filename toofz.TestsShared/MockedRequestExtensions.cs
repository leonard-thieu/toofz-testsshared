using System;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;

namespace toofz.TestsShared
{
    /// <summary>
    /// Provides extension methods for <see cref="MockedRequest"/>.
    /// </summary>
    public static class MockedRequestExtensions
    {
        /// <summary>
        /// Sets the response of the current <see cref="MockedRequest"/> with an "application/json" media type.
        /// </summary>
        /// <param name="source">The source mocked request.</param>
        /// <param name="content">The content to be serialized as JSON.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> is null.
        /// </exception>
        public static void RespondJson(this MockedRequest source, object content)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            source.RespondJson(JsonConvert.SerializeObject(content));
        }

        /// <summary>
        /// Sets the response of the current <see cref="MockedRequest"/> with an "application/json" media type.
        /// </summary>
        /// <param name="source">The source mocked request.</param>
        /// <param name="content">The raw JSON content of the response.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> is null.
        /// </exception>
        public static void RespondJson(this MockedRequest source, string content)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            source.Respond("application/json", content);
        }
    }
}
