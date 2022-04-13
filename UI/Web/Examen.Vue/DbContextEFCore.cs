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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(eb =>
            {
                eb.HasKey(u => u.IdUsuario);
            });
        }
    }
}
