using Microsoft.EntityFrameworkCore;

namespace JnjStudyCompoundChecker.DbContext
{
    public partial class SafetyRepositoryContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public SafetyRepositoryContext()
        {
        }

        public SafetyRepositoryContext(DbContextOptions<SafetyRepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Compound> Compound { get; set; }
        public virtual DbSet<Protocol> Protocol { get; set; }
        public virtual DbSet<ProtocolCompound> ProtocolCompound { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=dce-q-sftdb01.eplnet.wan;initial catalog=qa_safetyRepositorySponsor03_01;user id=qa_indsr01;password=YMbsP3@wKYXBSX2^");
            }
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compound>(entity =>
            {
                entity.HasIndex(e => e.OwnerId)
                    .HasName("IX_FK_CompoundSourceOrganization");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Deleted).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.DrugNumber).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.OwnerId).HasColumnName("Owner_Id");

                entity.Property(e => e.SourceId).HasMaxLength(255);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Protocol>(entity =>
            {
                entity.HasIndex(e => e.SourceOrganizationId)
                    .HasName("IX_FK_Protocol_SourceOrganization");

                entity.HasIndex(e => e.TherapeuticAreaId)
                    .HasName("IX_FK_Protocol_TherapeuticArea");

                entity.HasIndex(e => new { e.Id, e.Name, e.Number })
                    .HasName("IX_Protocol_Number");

                entity.HasIndex(e => new { e.Number, e.Id, e.Name })
                    .HasName("ix_ProtocolNumberIdName");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImageMimeType).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SourceId).HasMaxLength(255);

                entity.Property(e => e.SynopsisMimeType).HasMaxLength(50);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProtocolCompound>(entity =>
            {
                entity.HasKey(e => new { e.ProtocolsId, e.CompoundsId });

                entity.HasIndex(e => e.CompoundsId)
                    .HasName("IX_FK_ProtocolCompound_Compound");

                entity.HasIndex(e => new { e.ProtocolsId, e.CompoundsId })
                    .HasName("IX_FK_ProtocolCompound_Compound_covered");

                entity.Property(e => e.ProtocolsId).HasColumnName("Protocols_Id");

                entity.Property(e => e.CompoundsId).HasColumnName("Compounds_Id");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Deleted).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(100);

                entity.Property(e => e.IsImp).HasColumnName("IsIMP");

                entity.Property(e => e.SafetyAssessmentSource).HasMaxLength(50);

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(suser_sname())");

                entity.HasOne(d => d.Compounds)
                    .WithMany(p => p.ProtocolCompound)
                    .HasForeignKey(d => d.CompoundsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProtocolCompound_Compound");

                entity.HasOne(d => d.Protocols)
                    .WithMany(p => p.ProtocolCompound)
                    .HasForeignKey(d => d.ProtocolsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProtocolCompound_Protocol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
