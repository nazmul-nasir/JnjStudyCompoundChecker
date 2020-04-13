using System;
using System.Collections.Generic;

namespace JnjStudyCompoundChecker.Models.ResponseModels
{
    public class ProtocolCompoundResponse
    {
        public int ProtocolId { get; set; }
        public string ProtocolNumber { get; set; }
        public string ProtocolSourceId { get; set; }
        public List<CompoundResponse> CompoundResponses { get; set; }

        public ProtocolCompoundResponse()
        {
            CompoundResponses = new List<CompoundResponse>();
        }
    }
}
