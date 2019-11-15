using Newtonsoft.Json;
using System;
using System.Net;

namespace SBTechTestProject
{
    class Meta
    {
        public bool success;
        public int code;
        public string message;

        public HttpStatusCode StatusCode
        {
            get
            {
                return (HttpStatusCode)Enum.ToObject(typeof(HttpStatusCode), code);
            }
        }
    }

    [JsonObject()]
    class ApiResponse
    {
        [JsonProperty("_meta")]
        public Meta meta;
    }

    class UserResponse
    {
        [JsonProperty("_meta")]
        public Meta meta;

        [JsonProperty("result")]
        public User user;
    }
}
