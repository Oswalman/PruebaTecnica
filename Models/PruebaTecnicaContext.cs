using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace PruebaTecnica.Models
{
    public partial class PruebaTecnicaContext : DbContext
    {
        private readonly string _connectionString;
        public PruebaTecnicaContext()
        {
        }

        public PruebaTecnicaContext(DbContextOptions<PruebaTecnicaContext> options)
            : base(options)
        {
        }
        public PruebaTecnicaContext(IOptions<DbConnectionInfo> dbConnectionInfo)
        {
            _connectionString = dbConnectionInfo.Value.PruebaTecnicaContext;
        }

        public virtual DbSet<Ticket> Ticket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
        public void Commit()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.NoTicket);

                entity.ToTable("Ticket");

                entity.Property(e => e.FechaActualizacion).HasColumnType("date");

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }
     

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
