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

        public DbSet<EntradaHabilidadCa> HabilidadCandidato { get; set; } = default!;
        public DbSet<EntradaOfeHab> HabilidadOferta { get; set; } = default!;
        public DbSet<EntradaOferCa> OfertaCandidato { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // RELACIONES 

            // 1-PRIMERA RELACION UNO A MUCHOS REVISAR

            modelBuilder.Entity<FormacionAcademica>()
            .HasOne(formacion => formacion.Candidato)
            .WithMany(candidato => candidato.FormacionAcademicas)
            .HasForeignKey(k => k.CandidatoId);

            modelBuilder.Entity<Oferta>()
            .HasOne(oferta => oferta.Empresa)
            .WithMany(empresa => empresa.ofertas)
            .HasForeignKey(k => k.EmpresaId);


           // 2- SEGUNDA RELACION MUCHOS A MUCHOS

            // EntradaHabilidadCa


            modelBuilder.Entity<EntradaHabilidadCa>()
            .HasKey(ch => new { ch.CandidatoId, ch.HabilidadId });

            modelBuilder.Entity<EntradaHabilidadCa>()
                .HasOne(ch => ch.Candidato)
                .WithMany(c => c.HabilidadCandidatos)
                .HasForeignKey(ch => ch.CandidatoId);

            modelBuilder.Entity<EntradaHabilidadCa>()
                .HasOne(ch => ch.HabilidadesTecnicas)
                .WithMany(h => h.HabilidadCandidatos)
                .HasForeignKey(ch => ch.HabilidadId);

            // EntradaOfeHab

            modelBuilder.Entity<EntradaOfeHab>()
            .HasKey(ch => new { ch.OfertaId, ch.HabilidadId });

            modelBuilder.Entity<EntradaOfeHab>()
                .HasOne(ch => ch.Oferta)
                .WithMany(c => c.HabilidadOfertas)
                .HasForeignKey(ch => ch.OfertaId);

            modelBuilder.Entity<EntradaOfeHab>()
                .HasOne(ch => ch.HabilidadesTecnicas)
                .WithMany(h => h.HabilidadOfertas)
                .HasForeignKey(ch => ch.HabilidadId);

            // EntradaOferCa

            modelBuilder.Entity<EntradaOferCa>()
            .HasKey(ch => new { ch.CandidatoId, ch.OfertaId });

            modelBuilder.Entity<EntradaOferCa>()
                .HasOne(ch => ch.Candidato)
                .WithMany(c => c.OfertaCandidatos)
                .HasForeignKey(ch => ch.CandidatoId);

            modelBuilder.Entity<EntradaOferCa>()
                .HasOne(ch => ch.Oferta)
                .WithMany(h => h.OfertaCandidatos)
                .HasForeignKey(ch => ch.CandidatoId);




        }

    }
}
