using Microsoft.EntityFrameworkCore;
using Senail.InLock.WebApi.Codefirst.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senail.InLock.WebApi.Codefirst.Contexts
{
    /// <summary>
    /// Classe reponsavel pelo contexto do projeto
    /// Faz a comunicação entre API e BAnco de Dados
    /// </summary>
    public class InLockContext : DbContext
    {
        //Define as estidades do Banco de dados
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Estudio> Estudio { get; set; }

        public DbSet<Jogo> Jogo { get; set; }

        //Protected Porque tem informações do usuario do banco de dados.
        //Conexão de entrada

        /// <summary>
        /// define as opções de contrução de Banco de Dados
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DEV17\\SQLEXPRESS; Database=InLock_Games_Manha_CodeFirst; user Id=sa; pwd=sa@132");
            base.OnConfiguring(optionsBuilder);//O metodo é criado e dps é chamado, no caso a sring de conexão a cima é chamada através do 'base.OnConfiguring(optionsBuilder)'
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoUsuario>().HasData(
                new TipoUsuario
                {
                    IdTipoUsuario = 1,
                    Titulo = "Administrador"
                },
                new TipoUsuario
                {
                    IdTipoUsuario = 2,
                    Titulo = "Cliente"
                });

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    IdUsuario = 1,
                    Email = "Admin@dmin.com",
                    Senha = "Admin",
                    IdTipoUsuario = 1
                },
                new Usuario
                {
                    IdUsuario = 2,
                    Email = "cliente@cliente.com",
                    Senha = "cliente",
                    IdTipoUsuario = 2
                });

            modelBuilder.Entity<Estudio>().HasData(
                new Estudio{ IdEstudio = 1 , NomeEstudio = "Blizzard"},
                new Estudio { IdEstudio = 2, NomeEstudio = "Rockstar Studios" },
                new Estudio { IdEstudio = 3, NomeEstudio = "Square Enix" }
                );

            modelBuilder.Entity<Jogo>().HasData(
                new Jogo {
                IdJogo = 1,
                NomeJogo = "Red Dead Redemption II",
                DataLancamento = }
                );
        }
    }
}
