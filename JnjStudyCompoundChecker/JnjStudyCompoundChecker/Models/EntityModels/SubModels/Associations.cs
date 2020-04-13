using System.Collections.Generic;

namespace JnjStudyCompoundChecker.Models.EntityModels.SubModels
{
    public class Associations
    {
        public List<StudyAssociation> StudyAssociations { get; set; }
        public List<StudyCountryAssociation> StudyCountryAssociations { get; set; }
        public List<StudySiteAssociation> StudySiteAssociations { get; set; }
        public List<CompoundAssociation> CompoundAssociations { get; set; }
        public List<CountryAssociation> CountryAssociations { get; set; }
    }
}
