using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class Skill
    {
        public Skill()
        {
            AgendaRelatedSkill = new HashSet<AgendaRelatedSkill>();
            SpeakerRelatedSkill = new HashSet<SpeakerRelatedSkill>();
        }

        public string SkillId { get; set; }
        public string SkillTitle { get; set; }

        public virtual ICollection<AgendaRelatedSkill> AgendaRelatedSkill { get; set; }
        public virtual ICollection<SpeakerRelatedSkill> SpeakerRelatedSkill { get; set; }
    }
}
