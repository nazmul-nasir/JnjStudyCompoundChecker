using System.Collections.Generic;
using JnjStudyCompoundChecker.Models.EntityModels.SubModels;

namespace JnjStudyCompoundChecker.Models.EntityModels
{
    public class StudySite
    {
        public string SourceId { get; set; }
        public string SponsorName { get; set; }
        public List<StudyInfo> Studies { get; set; }
        public string InstitutionName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public Address Address { get; set; }
    }
}
