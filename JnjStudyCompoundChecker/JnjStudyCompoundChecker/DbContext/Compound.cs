using System;
using System.Collections.Generic;

namespace JnjStudyCompoundChecker.DbContext
{
    public partial class Compound
    {
        public Compound()
        {
            ProtocolCompound = new HashSet<ProtocolCompound>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? Deleted { get; set; }
        public string DeletedBy { get; set; }
        public string DrugNumber { get; set; }
        public int? OwnerId { get; set; }
        public string SourceId { get; set; }

        public virtual ICollection<ProtocolCompound> ProtocolCompound { get; set; }
    }
}
