using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class RecordStatus
    {
        public RecordStatus()
        {
            Event = new HashSet<Event>();
            EventAgenda = new HashSet<EventAgenda>();
            EventVenue = new HashSet<EventVenue>();
            SpeakerProfile = new HashSet<SpeakerProfile>();
            UserAccount = new HashSet<UserAccount>();
            UserDetail = new HashSet<UserDetail>();
        }

        public string RecordStatusId { get; set; }
        public string StatusText { get; set; }
        public string StatusDescription { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<EventAgenda> EventAgenda { get; set; }
        public virtual ICollection<EventVenue> EventVenue { get; set; }
        public virtual ICollection<SpeakerProfile> SpeakerProfile { get; set; }
        public virtual ICollection<UserAccount> UserAccount { get; set; }
        public virtual ICollection<UserDetail> UserDetail { get; set; }
    }
}
