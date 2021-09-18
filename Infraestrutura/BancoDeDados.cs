using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Infraestrutura
{
    public class BancoDeDados : DbContext
    {
        public BancoDeDados(IConfiguration configuration, DbContextOptions options) : base(options)
        {

        }

        private IConfiguration configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlServer(configuration.GetConnectionString("DbConn"));


        public DbSet<Livro> Livro { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
    }
}
