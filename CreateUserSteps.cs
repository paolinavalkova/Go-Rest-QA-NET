using TechTalk.SpecFlow;
using System.Net;
using FluentAssertions;
using SBTechTestProject.Client;

namespace SBTechTestProject
{
    [Binding]
    public class CreateUserSteps
    {

        private readonly UserClient client = new UserClient();
        private User user;
        private UserResponse response;

        [Given(@"a new User data")]
        public void GivenANewUserData()
        {
            user = User.CreateTestUser();
        }

        [When(@"the User is added")]
        public void WhenTheUserIsAdded()
        {
            response = client.CreateUser(user);
        }

        [Then(@"the User should be created")]
        public void ThenTheUserShouldBeCreated()
        {
            response.meta.StatusCode.Should().Be(HttpStatusCode.Created);
            response.user.Id.Should().NotBeNull();
            client.DeleteUser(response.user.Id);
        }
    }
}
