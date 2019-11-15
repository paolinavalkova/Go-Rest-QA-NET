using SBTechTestProject.Client;
using System;
using FluentAssertions;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SBTechTestProject
{
    [Binding]
    public class UpdateUserSteps
    {
        private const String NEW_ADDRESS = "Pencho Slaveikov 20";

        private readonly UserClient client = new UserClient();
        private User user;

        [Given(@"an User with wrong address")]
        public void GivenAnUserWithWrongAddress()
        {
            var response = client.CreateUser(User.CreateTestUser());
            user = response.user;
        }
        
        [When(@"the address is updated")]
        public void WhenTheAddressIsUpdated()
        {
            var updateData = new Dictionary<string, string>()
            {
                { "address", NEW_ADDRESS }
            };
            client.UpdateUser(user.Id, updateData);
        }
        
        [Then(@"the User should have the new address")]
        public void ThenTheUserShouldHaveTheNewAddress()
        {
            var updatedUser = client.GetUser(user.Id);
            updatedUser.Address.Should().Be(NEW_ADDRESS);
            client.DeleteUser(user.Id);
        }
    }
}
