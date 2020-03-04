using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    /// <summary>
    /// Repositório dos Estudios
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
       // private string stringConexao = "Data Source=DEV17\\SQLEXPRESS; initial catalog=InLock_Games_Manha; integrated security=true";
        private string stringConexao = "Data Source=DEV17\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Busca um estudio através do ID
        /// </summary>
        /// <param name="id">ID do estudio que será buscado</param>
        /// <returns>Retorna um estudio buscado</returns>
        public EstudioDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdEstudio, NomeEstudio FROM Estudio WHERE IdEstudio = @ID ";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Caso o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Instancia um objeto usuario 
                        EstudioDomain estudio = new EstudioDomain
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"])
                            ,
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                            
                        };

                        // Retorna o usuario buscado
                        return estudio;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO Estudio(NomeEstudio) " +
                                     "VALUES (@NomeEstudio)";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@NomeEstudio", novoEstudio.NomeEstudio);
                   
                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um estudio existente
        /// </summary>
        /// <param name="id">ID do estudio que será deletado</param>
        public void Deletar(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Estudio WHERE IdEstudio = @ID";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns>Retorna uma lista de estudios</returns>
        public List<EstudioDomain> Listar()
        {
            // Cria uma lista estudios onde serão armazenados os dados
            List<EstudioDomain> estudios = new List<EstudioDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdEstudio, NomeEstudio FROM Estudio";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto estudio 
                        EstudioDomain estudio = new EstudioDomain
                        {
                            
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"])
                            ,
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };

                        // Adiciona o usuario criado à lista usuarios
                        estudios.Add(estudio);
                    }
                }
            }

            // Retorna a lista de usuários
            return estudios;
        }

        /// <summary>
        /// Atualiza um estudio existente
        /// </summary>
        /// <param name="id">ID do estudio que será atualizado</param>
        /// <param name="EstudioAtualizado">Objeto EstudioAtualizado que será alterado</param>
        public void Atualizar(int id, EstudioDomain EstudioAtualizado)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Estudio " +
                                     "SET NomeEstudio = @NomeEstudio " +
                                     "WHERE IdEstudio = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NomeEstudio", EstudioAtualizado.NomeEstudio);
                    

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
