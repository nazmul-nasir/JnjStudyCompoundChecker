namespace JnjStudyCompoundChecker.Models.EntityModels.SubModels
{
    public class Compound
    {
        public string CompoundSourceId { get; set; }
        public string IsPrimary { get; set; }

        public void SetCompound(string id)
        {
            CompoundSourceId = id;
            IsPrimary = "true";
        }
    }
}
