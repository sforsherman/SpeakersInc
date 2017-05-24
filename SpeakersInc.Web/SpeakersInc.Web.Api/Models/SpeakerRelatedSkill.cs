using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class SpeakerRelatedSkill
    {
        public string RelatedSkillId { get; set; }
        public string SpeakerId { get; set; }
        public string SkillId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual SpeakerProfile Speaker { get; set; }
    }
}
