using SBTechTestProject.Client;
using FluentAssertions;
using TechTalk.SpecFlow;
using System.Net;

namespace SBTechTestProject
{
    [Binding]
    public class DeleteUserSteps
    {

        private readonly UserClient client = new UserClient();
        private User user;

        [Given(@"an User to delete")]
        public void GivenAnUserToDelete()
        {
            user = User.CreateTestUser();
        }
        
        [When(@"I deleted the user")]
        public void WhenIDeletedTheUser()
        {
            client.DeleteUser(user.Id);
        }
        
        [Then(@"the user shouldn't exist")]
        public void ThenTheUserShouldnTExist()
        {
            client.GetUserResponse(user.Id).StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
