using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class EventVenue
    {
        public string VenueId { get; set; }
        public string EventId { get; set; }
        public string VenueTitle { get; set; }
        public string BuildingNo { get; set; }
        public string BuildingName { get; set; }
        public string StreetName { get; set; }
        public string UnitNo { get; set; }
        public string PostalCode { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string RecordStatusId { get; set; }

        public virtual Event Event { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}
