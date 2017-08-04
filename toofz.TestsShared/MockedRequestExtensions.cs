﻿using Newtonsoft.Json;
using RichardSzalay.MockHttp;

namespace toofz.TestsShared
{
    public static class MockedRequestExtensions
    {
        public static void RespondJson(this MockedRequest source, object content)
        {
            source.RespondJson(JsonConvert.SerializeObject(content));
        }

        public static void RespondJson(this MockedRequest source, string content)
        {
            source.Respond("application/json", content);
        }
    }
}