using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarnetEmprendedor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public virtual DbSet<IdentityUser> IdentityUser { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
