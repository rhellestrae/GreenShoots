using System;

namespace GreenShoots.Entities
{
    public class UserDetails
    {
        public string TwitterId { get; set; }
        public string Name { get; set; }
        public string ScreenName { get; set; }
        public string Token { get; set; }
        public string TokenSecret { get; set; }

        public string LinkedInID { get; set; }
        public string LinkedInName { get; set; }
        public string LinkedInScreenName { get; set; }
        public string LinkedInToken { get; set; }
        public string LinkedInTokenSecret { get; set; }

        public bool IsAuthenticated
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Token);
            }
        }

        public UserDetails()
        {
        }
    }
}
