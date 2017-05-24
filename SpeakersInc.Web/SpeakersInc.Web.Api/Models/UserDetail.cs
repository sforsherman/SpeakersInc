using System;
using System.Collections.Generic;

namespace SpeakersInc.Web.Api.Models
{
    public partial class UserDetail
    {
        public string DetailId { get; set; }
        public string UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public string EducationInstitutionName { get; set; }
        public string Occupation { get; set; }
        public string OccupationLevelId { get; set; }
        public string AboutMeDescription { get; set; }
        public string CountryId { get; set; }
        public string CityId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string RecordStatusId { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual OccupationLevel OccupationLevel { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
        public virtual UserAccount User { get; set; }
    }
}
