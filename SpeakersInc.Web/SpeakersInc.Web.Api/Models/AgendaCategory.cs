using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class AgendaCategory
    {
        public AgendaCategory()
        {
            EventAgenda = new HashSet<EventAgenda>();
        }

        public string CategoryId { get; set; }
        public string CategoryTitle { get; set; }

        public virtual ICollection<EventAgenda> EventAgenda { get; set; }
    }
}
