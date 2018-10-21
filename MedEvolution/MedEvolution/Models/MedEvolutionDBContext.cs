using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;

namespace MedEvolution.Models
{
    public class MedEvolutionDbContext : DbContext
    {
        public MedEvolutionDbContext()
        {

        }
        
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Examen> Examen { get; set; }
        public DbSet<Privilegio> Privilegio { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<ConjuntoSignosVitales> ConjuntoSignosVitales { get; set; }
        public DbSet<Especialidad_Desempeniada> Especialidad_Desempeniada { get; set; }
        public DbSet<Horario_De_Atencion> Horario_De_Atencion { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Cita> Cita { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<OrdenExamen> OrdenExamen { get; set; }
        public DbSet<Receta> Receta { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Cita>()
                 .HasRequired(e => e.Medico);

            modelBuilder.Entity<Cita>()
                 .HasRequired(e => e.Paciente);

            modelBuilder.Entity<Cita>()
                 .HasRequired(e => e.Estado);

            modelBuilder.Entity<Clinica>()
                 .HasRequired(e => e.Director);

            modelBuilder.Entity<Clinica>()
                 .HasRequired(e => e.Direccion);

            modelBuilder.Entity<Consulta>()
                 .HasRequired(e => e.Signos);

            modelBuilder.Entity<Consulta>()
                 .HasRequired(e => e.Cita);

            modelBuilder.Entity<Consulta>()
                 .HasMany(e => e.OrdenesExamen)
                 .WithRequired()
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<Consulta>()
                .HasMany(e => e.Recetas)
                .WithRequired()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado>()
                 .HasRequired(e => e.Clinica);

            modelBuilder.Entity<Direccion>()
               .HasRequired(e => e.Municipio);

            modelBuilder.Entity<Municipio>()
               .HasRequired(e => e.Departamento);

            modelBuilder.Entity<Empleado>()
                 .HasRequired(e => e.Estado);

            modelBuilder.Entity<Medico>()
                 .HasRequired(e => e.Especialidad_Desempeniada);

            modelBuilder.Entity<Medico>()
                 .HasRequired(e => e.Horarios_De_Atencion);

            modelBuilder.Entity<Menu>()
                 .Property(e => e.Men_codigoMenu)
                 .IsOptional();

            modelBuilder.Entity<Paciente>()
                 .HasRequired(e => e.Estado);

            modelBuilder.Entity<Persona>()
                 .HasRequired(e => e.Direccion);

            modelBuilder.Entity<Rol>()
                 .HasMany(e => e.Privilegios)
                 .WithOptional()
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                 .HasMany(e => e.Menus)
                 .WithOptional()
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                 .HasMany(e => e.Rol)
                 .WithOptional()
                 .WillCascadeOnDelete(false);

        }

    }
}