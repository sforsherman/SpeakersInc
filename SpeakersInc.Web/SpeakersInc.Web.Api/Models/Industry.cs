using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class Industry
    {
        public Industry()
        {
            AgendaRelatedIndustry = new HashSet<AgendaRelatedIndustry>();
            IndustryField = new HashSet<IndustryField>();
            SpeakerRelatedIndustry = new HashSet<SpeakerRelatedIndustry>();
        }

        public string IndustryId { get; set; }
        public string IndustryTitle { get; set; }

        public virtual ICollection<AgendaRelatedIndustry> AgendaRelatedIndustry { get; set; }
        public virtual ICollection<IndustryField> IndustryField { get; set; }
        public virtual ICollection<SpeakerRelatedIndustry> SpeakerRelatedIndustry { get; set; }
    }
}
