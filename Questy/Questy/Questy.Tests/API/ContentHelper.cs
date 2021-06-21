using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Questy.Tests.API
{
    public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");

        // TODO: Implement long live token
        public static string GetToken()
            => "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6IlNsaW1lbG9yZCIsIkVtYWlsIjoidGF0dGVkZGV2QGdtYWlsLmNvbSIsIklzQWRtaW4iOiJUcnVlIiwiVXNlcklEIjoiMSIsImV4cCI6MTY1NTg0MTU2OCwiaXNzIjoiUXVlc3R5QVBJIiwiYXVkIjoiUXVlc3R5QVBJIn0.4OZlRBtzsLfUkxFDIhdt__BvTVjhNCxEbdIAx817zEw";
    }
}
