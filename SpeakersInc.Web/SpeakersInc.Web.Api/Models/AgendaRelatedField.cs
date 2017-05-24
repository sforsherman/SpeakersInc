using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class AgendaRelatedField
    {
        public string RelatedFieldId { get; set; }
        public string AgendaId { get; set; }
        public string FieldId { get; set; }

        public virtual EventAgenda Agenda { get; set; }
        public virtual IndustryField Field { get; set; }
    }
}
