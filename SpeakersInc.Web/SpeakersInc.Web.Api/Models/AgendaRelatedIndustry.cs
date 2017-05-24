using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class AgendaRelatedIndustry
    {
        public string RelatedIndustryId { get; set; }
        public string IndustryId { get; set; }
        public string AgendaId { get; set; }

        public virtual EventAgenda Agenda { get; set; }
        public virtual Industry Industry { get; set; }
    }
}
