using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class EventType
    {
        public EventType()
        {
            Event = new HashSet<Event>();
        }

        public string TypeId { get; set; }
        public string TypeTitle { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
