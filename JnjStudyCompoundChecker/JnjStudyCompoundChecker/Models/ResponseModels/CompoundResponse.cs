using System;

namespace JnjStudyCompoundChecker.Models.ResponseModels
{
    public class CompoundResponse
    {
        public string CompoundId { get; set; }
        public string CompoundName { get; set; }
        public string CompoundSourceId { get; set; }
        public DateTime Created { get; set; }
    }
}
