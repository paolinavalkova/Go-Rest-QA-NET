using SBTechTestProject.Client;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace SBTechTestProject
{
    [Binding]
    public class GetExistingUserSteps
    {
        private readonly UserClient client = new UserClient();
        private string existingUserId;
        private User user;

        [Given(@"an existing user")]
        public void GivenAnExistingUser()
        {
            var response = client.CreateUser(User.CreateTestUser());
            existingUserId = response.user.Id;
        }

        [When(@"I get a user with valid ID")]
        public void WhenIGetAUserWithValidID()
        {
            user = client.GetUser(existingUserId);
        }

        [Then(@"the user should exist")]
        public void ThenTheUserShouldExist()
        {
            user.Should().NotBeNull();
            user.Email.Should().Be(User.TEST_USER_EMAIL);
            client.DeleteUser(user.Id);
        }
    }
}
