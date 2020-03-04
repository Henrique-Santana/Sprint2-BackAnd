using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Repositories
{
    /// <summary>
    /// Repositório dos Filmes
    /// </summary>
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source - Nome do Servidor
        /// initial catalog - Nome do Banco de Dados
        /// integrated security=true - Faz a autenticação com o usuário do sistema
        /// user Id=sa; pwd=sa@132 - Faz a autenticação com um usuário específico, passando o logon e a senha
        /// </summary>
        //private string StringConexao = "Data Source=DESKTOP-NJ6LHN1\\SQLDEVELOPER; initial catalog=Filmes; integrated security=true;";
        private string stringConexao = "Data Source=DEV17\\SQLEXPRESS; initial catalog=Filmes_manha; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Retorna uma lista com os filmes cadastrados no bd</returns>
        public List <FilmeDomain> Listar()
        {
            //Cria uma lista onde sera armazenado os filmes;
            List<FilmeDomain> Filmes = new List<FilmeDomain>();

            /// Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a string com o comando desajado
                string queryListFilmes = "SELECT IdFilme, Titulo, IdGenero FROM Filmes";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryListFilmes, con))
                {
                    //Executa a queryListFilmes 
                    rdr = cmd.ExecuteReader();

                    //Laço de repetição que se repitira enquanto tiver linhas para ler;
                    while (rdr.Read())
                    {
                        //Cria um Filme para armazenar o filme da linha lida 
                        FilmeDomain Filme = new FilmeDomain
                        {
                            
                            //// Atribui à propriedade IdGenero o valor da primeira coluna da tabela do banco
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            Titulo = rdr["Titulo"].ToString(),

                            //
                            IdGenero = Convert.ToInt32(rdr["IdGenero"])
                        };

                        //Adiciona os dados armazendo em Filme em FIlmes
                        Filmes.Add(Filme);
                    }
                }
            }

            // Retorna a lista de Filmes
            return Filmes;
        }

        /// <summary>
        /// Busca um Filme pelo ID
        /// </summary>
        /// <param name="id">ID do Filme que será buscado</param>
        /// <returns>Retorna um filme buscado ou null caso não seja encontrado</returns>
        public FilmeDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdFilme, Titulo FROM Filme WHERE IdFilme = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader fazer a leitura no banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Caso a o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Cria um objeto genero
                        FilmeDomain filme = new FilmeDomain
                        {
                            // Atribui à propriedade IdFilme o valor da coluna "IdFilme" da tabela do banco
                            IdFilme = Convert.ToInt32(rdr["IdFilme"])

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            ,
                            Titulo = rdr["Titulo"].ToString()
                        };

                        // Retorna o genero com os dados obtidos
                        return filme;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }
    }
}
