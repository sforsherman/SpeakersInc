using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
            UserDetail = new HashSet<UserDetail>();
        }

        public string CountryId { get; set; }
        public string CountryTitle { get; set; }

        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<UserDetail> UserDetail { get; set; }
    }
}
