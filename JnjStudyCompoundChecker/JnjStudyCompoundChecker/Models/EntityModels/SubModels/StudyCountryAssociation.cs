namespace JnjStudyCompoundChecker.Models.EntityModels.SubModels
{
    public class StudyCountryAssociation
    {
        public string StudySourceId { get; set; }
        public string Country { get; set; }
        public string TransmissionFailureResponsible { get; set; }
        public string UnblindedAccess { get; set; }
        public string AlertEmail { get; set; }
    }
}
