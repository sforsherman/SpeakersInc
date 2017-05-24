using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class AgendaRelatedSkill
    {
        public string RelatedSkillId { get; set; }
        public string AgendaId { get; set; }
        public string SkillId { get; set; }

        public virtual EventAgenda Agenda { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
