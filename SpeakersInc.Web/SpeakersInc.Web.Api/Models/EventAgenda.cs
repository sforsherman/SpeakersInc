using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class EventAgenda
    {
        public EventAgenda()
        {
            AgendaRelatedField = new HashSet<AgendaRelatedField>();
            AgendaRelatedIndustry = new HashSet<AgendaRelatedIndustry>();
            AgendaRelatedSkill = new HashSet<AgendaRelatedSkill>();
        }

        public string AgendaId { get; set; }
        public string EventId { get; set; }
        public string SpeakerId { get; set; }
        public string CategoryId { get; set; }
        public string AgendaTitle { get; set; }
        public string AgendaDescription { get; set; }
        public DateTime TimeSlotStartTime { get; set; }
        public DateTime TimeSlotEndTime { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string RecordStatusId { get; set; }

        public virtual ICollection<AgendaRelatedField> AgendaRelatedField { get; set; }
        public virtual ICollection<AgendaRelatedIndustry> AgendaRelatedIndustry { get; set; }
        public virtual ICollection<AgendaRelatedSkill> AgendaRelatedSkill { get; set; }
        public virtual AgendaCategory Category { get; set; }
        public virtual Event Event { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
        public virtual SpeakerProfile Speaker { get; set; }
    }
}
