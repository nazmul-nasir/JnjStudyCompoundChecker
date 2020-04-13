namespace JnjStudyCompoundChecker.Models.EntityModels.SubModels
{
    public class Indication
    {
        public string IndicationSourceId { get; set; }
        public string IsPrimary { get; set; }

        public void SetIndication(string id)
        {
            IndicationSourceId = id;
            IsPrimary = "true";
        }
    }
}
