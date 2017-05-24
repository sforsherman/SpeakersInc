using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class SpeakerRelatedField
    {
        public string RelatedFieldId { get; set; }
        public string SpeakerId { get; set; }
        public string FieldId { get; set; }

        public virtual IndustryField Field { get; set; }
        public virtual SpeakerProfile Speaker { get; set; }
    }
}
