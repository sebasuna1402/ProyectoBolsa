﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoBolsa.Data;

#nullable disable

namespace ProyectoBolsa.Migrations
{
    [DbContext(typeof(MyApiContext))]
    [Migration("20230508024400_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Entidades.Candidato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumenPersonal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Candidato");
                });

            modelBuilder.Entity("DataAccess.Entidades.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("DataAccess.Entidades.FormacionAcademica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Años_Estudio")
                        .HasColumnType("int");

                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<string>("Fecha_Culminacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Formacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.ToTable("FormacionAcademica");
                });

            modelBuilder.Entity("DataAccess.Entidades.HabilidadCandidato", b =>
                {
                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<int>("HabilidadId")
                        .HasColumnType("int");

                    b.HasKey("CandidatoId", "HabilidadId");

                    b.HasIndex("HabilidadId");

                    b.ToTable("HabilidadCandidato");
                });

            modelBuilder.Entity("DataAccess.Entidades.HabilidadOferta", b =>
                {
                    b.Property<int>("OfertaId")
                        .HasColumnType("int");

                    b.Property<int>("HabilidadId")
                        .HasColumnType("int");

                    b.HasKey("OfertaId", "HabilidadId");

                    b.HasIndex("HabilidadId");

                    b.ToTable("HabilidadOferta");
                });

            modelBuilder.Entity("DataAccess.Entidades.HabilidadesTecnicas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HabilidadesTecnicas");
                });

            modelBuilder.Entity("DataAccess.Entidades.Oferta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Oferta");
                });

            modelBuilder.Entity("DataAccess.Entidades.OfertaCandidato", b =>
                {
                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<int>("OfertaId")
                        .HasColumnType("int");

                    b.HasKey("CandidatoId", "OfertaId");

                    b.ToTable("OfertaCandidato");
                });

            modelBuilder.Entity("DataAccess.Entidades.FormacionAcademica", b =>
                {
                    b.HasOne("DataAccess.Entidades.Candidato", "Candidato")
                        .WithMany("FormacionAcademicas")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");
                });

            modelBuilder.Entity("DataAccess.Entidades.HabilidadCandidato", b =>
                {
                    b.HasOne("DataAccess.Entidades.Candidato", "Candidato")
                        .WithMany("HabilidadCandidatos")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entidades.HabilidadesTecnicas", "HabilidadesTecnicas")
                        .WithMany("HabilidadCandidatos")
                        .HasForeignKey("HabilidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");

                    b.Navigation("HabilidadesTecnicas");
                });

            modelBuilder.Entity("DataAccess.Entidades.HabilidadOferta", b =>
                {
                    b.HasOne("DataAccess.Entidades.HabilidadesTecnicas", "HabilidadesTecnicas")
                        .WithMany("HabilidadOfertas")
                        .HasForeignKey("HabilidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entidades.Oferta", "Oferta")
                        .WithMany("HabilidadOfertas")
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HabilidadesTecnicas");

                    b.Navigation("Oferta");
                });

            modelBuilder.Entity("DataAccess.Entidades.Oferta", b =>
                {
                    b.HasOne("DataAccess.Entidades.Empresa", "Empresa")
                        .WithMany("ofertas")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("DataAccess.Entidades.OfertaCandidato", b =>
                {
                    b.HasOne("DataAccess.Entidades.Candidato", "Candidato")
                        .WithMany("OfertaCandidatos")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entidades.Oferta", "Oferta")
                        .WithMany("OfertaCandidatos")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");

                    b.Navigation("Oferta");
                });

            modelBuilder.Entity("DataAccess.Entidades.Candidato", b =>
                {
                    b.Navigation("FormacionAcademicas");

                    b.Navigation("HabilidadCandidatos");

                    b.Navigation("OfertaCandidatos");
                });

            modelBuilder.Entity("DataAccess.Entidades.Empresa", b =>
                {
                    b.Navigation("ofertas");
                });

            modelBuilder.Entity("DataAccess.Entidades.HabilidadesTecnicas", b =>
                {
                    b.Navigation("HabilidadCandidatos");

                    b.Navigation("HabilidadOfertas");
                });

            modelBuilder.Entity("DataAccess.Entidades.Oferta", b =>
                {
                    b.Navigation("HabilidadOfertas");

                    b.Navigation("OfertaCandidatos");
                });
#pragma warning restore 612, 618
        }
    }
}
