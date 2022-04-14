using Examen.Core.COMMON.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Vue
{
    public class DbContextEFCore : DbContext
    {
        public DbContextEFCore([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<TipoContacto> TipoContacto { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(eb =>
            {
                eb.HasKey(u => u.IdUsuario);
            });
            modelBuilder.Entity<EstadoCivil>(e =>
            {
                e.HasKey(u => u.IdEstadoCivil);
            });
            modelBuilder.Entity<TipoContacto>(e =>
            {
                e.HasKey(u => u.IdTipoContacto);
            });
        }
    }
}
