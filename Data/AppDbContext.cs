using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoNaruto.Models;

namespace ProjetoNaruto.Data
{
    //banco herda prorpiedade do EntityFramework (DbContext)
    public class AppDbContext : DbContext
    {
        // cria o schema para criar o banco
        public AppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Personagem> Naruto {get; set; }   
    }
}