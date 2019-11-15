using Newtonsoft.Json;

namespace SBTechTestProject
{
    [JsonObject()]
    class User
    {
        public const string TEST_USER_EMAIL = "jane_doe@abv.bg";

        public static User CreateTestUser()
        {
            return new User
            {
                FirstName = "Jane",
                LastName = "Doe",
                Gender = "female",
                Dob = "1981-06-15",
                Email = TEST_USER_EMAIL,
                Phone = "+359883765821",
                Website = "https://jane-doe.bg",
                Address = "Kazanlak 12",
                Status = "active"
            };
        }

        [JsonProperty("id")]
        public string Id { set; get; }

        [JsonProperty("first_name")]
        public string FirstName { set; get; }

        [JsonProperty("last_name")]
        public string LastName { set; get; }

        [JsonProperty("gender")]
        public string Gender { set; get; }

        [JsonProperty("dob")]
        public string Dob { set; get; }

        [JsonProperty("email")]
        public string Email { set; get; }

        [JsonProperty("phone")]
        public string Phone { set; get; }

        [JsonProperty("website")]
        public string Website { set; get; }

        [JsonProperty("address")]
        public string Address { set; get; }

        [JsonProperty("status")]
        public string Status { set; get; }
    }
}
