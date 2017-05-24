using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class EventCategory
    {
        public EventCategory()
        {
            Event = new HashSet<Event>();
        }

        public string CategoryId { get; set; }
        public string CategoryTitle { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
