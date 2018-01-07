using Microsoft.EntityFrameworkCore;

namespace RH.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<Processo> Processos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcessoTecnologia>()
                .HasKey(pt => new { pt.ProcessoId, pt.TecnologiaId });

            modelBuilder.Entity<CandidatoTecnologia>()
             .HasKey(ct => new { ct.CandidatoId, ct.TecnologiaId });

            modelBuilder.Entity<CandidatoProcesso>()
         .HasKey(cp => new { cp.CandidatoId, cp.ProcessoId });
        }


    }
}
