using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class Event
    {
        public Event()
        {
            EventAgenda = new HashSet<EventAgenda>();
            EventVenue = new HashSet<EventVenue>();
        }

        public string EventId { get; set; }
        public string EventTypeId { get; set; }
        public string EventCategoryId { get; set; }
        public string EventVenueId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public bool? IsOneDayEvent { get; set; }
        public string OrganizerUserId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string RecordStatusId { get; set; }

        public virtual ICollection<EventAgenda> EventAgenda { get; set; }
        public virtual ICollection<EventVenue> EventVenue { get; set; }
        public virtual EventCategory EventCategory { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}
