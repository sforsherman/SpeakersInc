using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class UserType
    {
        public UserType()
        {
            UserAccount = new HashSet<UserAccount>();
        }

        public string TypeId { get; set; }
        public string TypeText { get; set; }
        public string TypeDescription { get; set; }

        public virtual ICollection<UserAccount> UserAccount { get; set; }
    }
}
