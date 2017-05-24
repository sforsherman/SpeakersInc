using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class SpeakerProfile
    {
        public SpeakerProfile()
        {
            EventAgenda = new HashSet<EventAgenda>();
            SpeakerRelatedField = new HashSet<SpeakerRelatedField>();
            SpeakerRelatedIndustry = new HashSet<SpeakerRelatedIndustry>();
            SpeakerRelatedSkill = new HashSet<SpeakerRelatedSkill>();
        }

        public string SpeakerId { get; set; }
        public string UserId { get; set; }
        public double? SpeakerRating { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string RecordStatusId { get; set; }

        public virtual ICollection<EventAgenda> EventAgenda { get; set; }
        public virtual ICollection<SpeakerRelatedField> SpeakerRelatedField { get; set; }
        public virtual ICollection<SpeakerRelatedIndustry> SpeakerRelatedIndustry { get; set; }
        public virtual ICollection<SpeakerRelatedSkill> SpeakerRelatedSkill { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
        public virtual UserAccount User { get; set; }
    }
}
