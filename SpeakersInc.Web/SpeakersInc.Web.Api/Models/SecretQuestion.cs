using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class SecretQuestion
    {
        public SecretQuestion()
        {
            UserAccountSecretQuestion1 = new HashSet<UserAccount>();
            UserAccountSecretQuestion2 = new HashSet<UserAccount>();
            UserAccountSecretQuestion3 = new HashSet<UserAccount>();
        }

        public string SecretQuestionId { get; set; }
        public string SecretQuestionText { get; set; }

        public virtual ICollection<UserAccount> UserAccountSecretQuestion1 { get; set; }
        public virtual ICollection<UserAccount> UserAccountSecretQuestion2 { get; set; }
        public virtual ICollection<UserAccount> UserAccountSecretQuestion3 { get; set; }
    }
}
