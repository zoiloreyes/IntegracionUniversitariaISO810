using IntegracionUniversitariaISO810.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegracionUniversitariaISO810.Context
{
    public class IntegracionDBContext : DbContext
    {
        public IntegracionDBContext(DbContextOptions<IntegracionDBContext> options) : base(options)
        {
        }

        public DbSet<DatoAcademico> DatosAcademicos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Pensum> Pensums { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
    }
}
