using System;
using System.Collections.Generic;

namespace JnjStudyCompoundChecker.DbContext
{
    public partial class ProtocolCompound
    {
        public int ProtocolsId { get; set; }
        public int CompoundsId { get; set; }
        public bool IsImp { get; set; }
        public string SafetyAssessmentSource { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? Deleted { get; set; }
        public string DeletedBy { get; set; }

        public virtual Compound Compounds { get; set; }
        public virtual Protocol Protocols { get; set; }
    }
}
