using Newtonsoft.Json;
using RestSharp;

namespace SBTechTestProject.Client
{
    class RequestBuilder
    {
        private const string ACCESS_TOKEN = "TPocU1p2nawMIlUtuwwlayQ3GlS526fZqeO7";

        public static RestRequest PostRequest(string resource, object payload)
        {
            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {ACCESS_TOKEN}");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            request.Method = Method.POST;
            request.Resource = resource;

            string body = JsonConvert.SerializeObject(payload);
            request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            return request;
        }

        public static RestRequest PutRequest(string resource, object payload)
        {
            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {ACCESS_TOKEN}");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            request.Method = Method.PUT;
            request.Resource = resource;

            string body = JsonConvert.SerializeObject(payload);
            request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            return request;
        }

        public static RestRequest DeleteRequest(string resource)
        {
            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {ACCESS_TOKEN}");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            request.Method = Method.DELETE;
            request.Resource = resource;

            return request;
        }

        public static RestRequest GetRequest(string resource)
        {
            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {ACCESS_TOKEN}");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            request.Method = Method.GET;
            request.Resource = resource;

            return request;
        }


    }
}
