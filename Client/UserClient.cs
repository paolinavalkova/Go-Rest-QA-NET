using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace SBTechTestProject.Client
{
    class UserClient
    {

        private readonly RestClient _client;

        public UserClient()
        {
            _client = new RestClient("https://gorest.co.in")
            {
                FollowRedirects = false
            };
        }

        public IRestResponse SendRequest(IRestRequest request)
        {
            return _client.Execute(request);
        }

        public UserResponse CreateUser(User user)
        {
            var request = RequestBuilder.PostRequest("/public-api/users", user);
            var response = SendRequest(request);
            return JsonConvert.DeserializeObject<UserResponse>(response.Content);
        }

        public UserResponse UpdateUser(string userId, Dictionary<string, string> updateData)
        {
            var request = RequestBuilder.PutRequest($"/public-api/users/{userId}", updateData);
            var response = SendRequest(request);
            return JsonConvert.DeserializeObject<UserResponse>(response.Content);
        }

        public User GetUser(string userId)
        {
            var response = GetUserResponse(userId);
            return JsonConvert.DeserializeObject<UserResponse>(response.Content).user;
        }

        public IRestResponse GetUserResponse(string userId)
        {
            var request = RequestBuilder.GetRequest($"/public-api/users/{userId}");
            return SendRequest(request);
        }

        public void DeleteUser(string userId)
        {
            var request = RequestBuilder.DeleteRequest($"/public-api/users/{userId}");
            SendRequest(request);
        }
    }
}
