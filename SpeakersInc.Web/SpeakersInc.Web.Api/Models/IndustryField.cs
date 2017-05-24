using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class IndustryField
    {
        public IndustryField()
        {
            AgendaRelatedField = new HashSet<AgendaRelatedField>();
            SpeakerRelatedField = new HashSet<SpeakerRelatedField>();
        }

        public string FieldId { get; set; }
        public string IndustryId { get; set; }
        public string FieldTitle { get; set; }

        public virtual ICollection<AgendaRelatedField> AgendaRelatedField { get; set; }
        public virtual ICollection<SpeakerRelatedField> SpeakerRelatedField { get; set; }
        public virtual Industry Industry { get; set; }
    }
}
