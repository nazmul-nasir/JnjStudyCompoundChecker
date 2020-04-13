using System;
using System.Collections.Generic;

namespace JnjStudyCompoundChecker.DbContext
{
    public partial class Protocol
    {
        public Protocol()
        {
            ProtocolCompound = new HashSet<ProtocolCompound>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public byte[] Synopsis { get; set; }
        public string SynopsisMimeType { get; set; }
        public byte[] Image { get; set; }
        public string ImageMimeType { get; set; }
        public int SourceOrganizationId { get; set; }
        public int? TherapeuticAreaId { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public string SourceId { get; set; }

        public virtual ICollection<ProtocolCompound> ProtocolCompound { get; set; }
    }
}
