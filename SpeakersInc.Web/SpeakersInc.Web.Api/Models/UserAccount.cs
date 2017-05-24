using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            SpeakerProfile = new HashSet<SpeakerProfile>();
            UserDetail = new HashSet<UserDetail>();
        }

        public string UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserTypeId { get; set; }
        public string SecretQuestion1Id { get; set; }
        public string SecretAnswer1 { get; set; }
        public string SecretQuestion2Id { get; set; }
        public string SecretAnswer2 { get; set; }
        public string SecretQuestion3Id { get; set; }
        public string SecretAnswer3 { get; set; }
        public bool? IsActivated { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string RecordStatusId { get; set; }

        public virtual ICollection<SpeakerProfile> SpeakerProfile { get; set; }
        public virtual ICollection<UserDetail> UserDetail { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
        public virtual SecretQuestion SecretQuestion1 { get; set; }
        public virtual SecretQuestion SecretQuestion2 { get; set; }
        public virtual SecretQuestion SecretQuestion3 { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
