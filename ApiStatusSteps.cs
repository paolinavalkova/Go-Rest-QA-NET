using TechTalk.SpecFlow;
using System.Net;
using FluentAssertions;
using SBTechTestProject.Client;
using RestSharp;
using Newtonsoft.Json;

namespace SBTechTestProject
{
    [Binding]
    public class ApiStatusSteps
    {
        private UserClient client;
        private IRestResponse response;
        private ApiResponse apiResponse;

        [Given(@"I have a REST client")]
        public void GivenIHaveARESTClient()
        {
            client = new UserClient();
        }

        [When(@"make a request")]
        public void WhenMakeARequest()
        {           
            response = client.SendRequest(RequestBuilder.GetRequest("/public-api/users"));
        }

        [Then(@"the API response should be ok")]
        public void ThenTheAPIResponseShouldBeOk()
        {
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [When(@"I make a request without access token")]
        public void WhenIMakeARequestWithoutAccessToken()
        {
            var request = new RestRequest();
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            request.Method = Method.GET;
            request.Resource = "/public-api/users";
            var response = client.SendRequest(request);

            apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
        }

        [Then(@"the request should fail")]
        public void ThenTheRequestShouldFail()
        {
            apiResponse.meta.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

    }
}
