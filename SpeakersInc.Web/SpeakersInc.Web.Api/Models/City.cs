using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class City
    {
        public City()
        {
            UserDetail = new HashSet<UserDetail>();
        }

        public string CityId { get; set; }
        public string CountryId { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<UserDetail> UserDetail { get; set; }
        public virtual Country Country { get; set; }
    }
}
