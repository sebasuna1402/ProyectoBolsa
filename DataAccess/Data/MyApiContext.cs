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

        public DbSet<EntradaHabilidadCa> EntradaHabilidadCa { get; set; } = default!;
        public DbSet<EntradaOfeHab> EntradaOfeHab { get; set; } = default!;
        public DbSet<EntradaOferCa> EntradaOferCa { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // RELACIONES 

            // 1-PRIMERA RELACION UNO A MUCHOS REVISAR

            modelBuilder.Entity<FormacionAcademica>()
            .HasOne(formacion => formacion.Candidato)
            .WithMany(candidato => candidato.FormacionAcads)
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
                .WithMany(c => c.EntradaHabilidadCa)
                .HasForeignKey(ch => ch.CandidatoId);

            modelBuilder.Entity<EntradaHabilidadCa>()
                .HasOne(ch => ch.HabilidadesTecnicas)
                .WithMany(h => h.EntradaHabilidadCa)
                .HasForeignKey(ch => ch.HabilidadId);

            // EntradaOfeHab

            modelBuilder.Entity<EntradaOfeHab>()
            .HasKey(ch => new { ch.OfertaId, ch.HabilidadId });

            modelBuilder.Entity<EntradaOfeHab>()
                .HasOne(ch => ch.Oferta)
                .WithMany(c => c.EntradaOfeHab)
                .HasForeignKey(ch => ch.OfertaId);

            modelBuilder.Entity<EntradaOfeHab>()
                .HasOne(ch => ch.HabilidadesTecnicas)
                .WithMany(h => h.EntradaOfeHab)
                .HasForeignKey(ch => ch.HabilidadId);

            // EntradaOferCa

            modelBuilder.Entity<EntradaOferCa>()
            .HasKey(ch => new { ch.CandidatoId, ch.OfertaId });

            modelBuilder.Entity<EntradaOferCa>()
                .HasOne(ch => ch.Candidato)
                .WithMany(c => c.EntradaOferCa)
                .HasForeignKey(ch => ch.CandidatoId);

            modelBuilder.Entity<EntradaOferCa>()
                .HasOne(ch => ch.Oferta)
                .WithMany(h => h.EntradaOferCa)
                .HasForeignKey(ch => ch.CandidatoId);




        }

    }
}
