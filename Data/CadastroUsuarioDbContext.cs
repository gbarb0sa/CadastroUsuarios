using CadastroUsuarios.Data.Map;
using CadastroUsuarios.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CadastroUsuarios.Data
{
    public class CadastroUsuarioDbContext : DbContext
    {
        public CadastroUsuarioDbContext(DbContextOptions<CadastroUsuarioDbContext> options) : base(options){}
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(builder);
        }

    }
}
