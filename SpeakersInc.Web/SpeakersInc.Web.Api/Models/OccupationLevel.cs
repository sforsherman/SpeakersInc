using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class OccupationLevel
    {
        public OccupationLevel()
        {
            UserDetail = new HashSet<UserDetail>();
        }

        public string OccupationLevelId { get; set; }
        public string LevelTitle { get; set; }

        public virtual ICollection<UserDetail> UserDetail { get; set; }
    }
}
