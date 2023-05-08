using DataAccess.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProyectoBolsa.Data
{
    public class MyApiContext : DbContext
    {
        public MyApiContext(DbContextOptions<MyApiContext> options)
          : base(options)
        {

        }

        // Relaciones de uno a muchos
        public DbSet<Candidato> Candidato { get; set; } = default!;
        public DbSet<FormacionAcademica> FormacionAcademica { get; set; } = default!;
        public DbSet<Empresa> Empresa { get; set; } = default!;
        public DbSet<Oferta> Oferta { get; set; } = default!;
        public DbSet<HabilidadesTecnicas> HabilidadesTecnicas { get; set; } = default!;

        // Relaciones de muchos a muchos

        public DbSet<HabilidadCandidato> HabilidadCandidato { get; set; } = default!;
        public DbSet<HabilidadOferta> HabilidadOferta { get; set; } = default!;
        public DbSet<OfertaCandidato> OfertaCandidato { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // uno a muchos

            modelBuilder.Entity<FormacionAcademica>()
            .HasOne(formacion => formacion.Candidato)
            .WithMany(candidato => candidato.FormacionAcademicas)
            .HasForeignKey(k => k.CandidatoId);

            modelBuilder.Entity<Oferta>()
            .HasOne(oferta => oferta.Empresa)
            .WithMany(empresa => empresa.ofertas)
            .HasForeignKey(k => k.EmpresaId);


            // muchos a muchos

            // CandidatoHabilidad

            modelBuilder.Entity<HabilidadCandidato>()
            .HasKey(ch => new { ch.CandidatoId, ch.HabilidadId });

            modelBuilder.Entity<HabilidadCandidato>()
                .HasOne(ch => ch.Candidato)
                .WithMany(c => c.HabilidadCandidatos)
                .HasForeignKey(ch => ch.CandidatoId);

            modelBuilder.Entity<HabilidadCandidato>()
                .HasOne(ch => ch.HabilidadesTecnicas)
                .WithMany(h => h.HabilidadCandidatos)
                .HasForeignKey(ch => ch.HabilidadId);

            // OfertaHabilidad

            modelBuilder.Entity<HabilidadOferta>()
            .HasKey(ch => new { ch.OfertaId, ch.HabilidadId });

            modelBuilder.Entity<HabilidadOferta>()
                .HasOne(ch => ch.Oferta)
                .WithMany(c => c.HabilidadOfertas)
                .HasForeignKey(ch => ch.OfertaId);

            modelBuilder.Entity<HabilidadOferta>()
                .HasOne(ch => ch.HabilidadesTecnicas)
                .WithMany(h => h.HabilidadOfertas)
                .HasForeignKey(ch => ch.HabilidadId);

            // CandidatoOferta

            modelBuilder.Entity<OfertaCandidato>()
            .HasKey(ch => new { ch.CandidatoId, ch.OfertaId });

            modelBuilder.Entity<OfertaCandidato>()
                .HasOne(ch => ch.Candidato)
                .WithMany(c => c.OfertaCandidatos)
                .HasForeignKey(ch => ch.CandidatoId);

            modelBuilder.Entity<OfertaCandidato>()
                .HasOne(ch => ch.Oferta)
                .WithMany(h => h.OfertaCandidatos)
                .HasForeignKey(ch => ch.CandidatoId);




        }

    }
}
