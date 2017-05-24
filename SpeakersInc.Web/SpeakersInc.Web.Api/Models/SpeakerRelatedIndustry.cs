using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class SpeakerRelatedIndustry
    {
        public string RelatedIndustryId { get; set; }
        public string SpeakerId { get; set; }
        public string IndustryId { get; set; }

        public virtual Industry Industry { get; set; }
        public virtual SpeakerProfile Speaker { get; set; }
    }
}
