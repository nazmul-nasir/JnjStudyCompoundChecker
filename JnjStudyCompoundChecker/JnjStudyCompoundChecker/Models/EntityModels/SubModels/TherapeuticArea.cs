namespace JnjStudyCompoundChecker.Models.EntityModels.SubModels
{
    public class TherapeuticArea
    {
        public string TherapeuticAreaSourceId { get; set; }
        public string IsPrimary { get; set; }

        public void SetTherapeuticArea(string id)
        {
            TherapeuticAreaSourceId = id;
            IsPrimary = "true";
        }
    }
}
