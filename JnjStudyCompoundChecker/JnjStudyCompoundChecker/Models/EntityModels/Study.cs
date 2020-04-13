using System.Collections.Generic;

namespace JnjStudyCompoundChecker.Models.EntityModels
{
    public class Study
    {
        public string SourceId { get; set; }
        public string SponsorName { get; set; }
        public string UniqueName { get; set; }
        public string FullName { get; set; }
        public string ProtocolNumber { get; set; }
        public string StudyTitle { get; set; }
        public string Status { get; set; }
        public string StudyPhase { get; set; }

        public List<SubModels.TherapeuticArea> StudyTherapeuticAreas { get; set; }
        public List<SubModels.Indication> StudyIndications { get; set; }
        public List<SubModels.Compound> StudyCompounds { get; set; }

        public string PlannedStartDate { get; set; }
        public string PlannedEndDate { get; set; }
        public List<string> Countries { get; set; }
        public string ProvisioningEmail { get; set; }
        public string LMSTemplate { get; set; }
    }
}
