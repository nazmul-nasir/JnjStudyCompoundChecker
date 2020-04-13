using JnjStudyCompoundChecker.Models.EntityModels.SubModels;

namespace JnjStudyCompoundChecker.Models.EntityModels
{
    public class StudyTeam
    {
        public string SourceId { get; set; }
        public string StudySourceId { get; set; }
        public string TeamId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationType { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Status { get; set; }
        public string Country { get; set; }
        public Address Address { get; set; }
    }
}
