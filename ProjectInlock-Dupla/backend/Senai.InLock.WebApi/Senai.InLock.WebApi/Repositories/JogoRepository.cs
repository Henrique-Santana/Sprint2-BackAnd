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
    /// Repositório dos Jogos
    /// </summary>
    public class JogoRepository : IJogoRepository 
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
        //private string stringConexao = "Data Source=DEV17\\SQLEXPRESS; initial catalog=InLock_Games_Manha; integrated security=true";
        private string stringConexao = "Data Source=DEV17\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Busca um jogo através do ID
        /// </summary>
        /// <param name="id">ID do jogo que será buscado</param>
        /// <returns>Retorna um jogo buscado</returns>
        public JogoDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT J.IdJogo, E.IdEstudio, E.NomeEstudio, J.NomeJogo, J.Descricao, J.DataLancamento, J.Valor FROM Jogo J INNER JOIN Estudio E ON J.IdEstudio = E.IdEstudio WHERE IdJogo = @ID";

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
                        JogoDomain jogo = new JogoDomain
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdJogo = Convert.ToInt32(rdr["IdJogo"])
                            ,
                            NomeJogo = rdr["NomeJogo"].ToString()
                            ,
                            Descricao = rdr["Descricao"].ToString()
                            ,
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"])
                            ,
                            Valor = Convert.ToDouble(rdr["Valor"])
                            ,
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"])
                            ,
                            Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"])
                                ,
                                NomeEstudio = rdr["NomeEstudio"].ToString()
                            }
                        };

                        // Retorna o usuario buscado
                        return jogo;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        public void Cadastrar(JogoDomain novoJogo)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO Jogo(NomeJogo, Descricao, DataLancamento, Valor, IdEstudio) " +
                                     "VALUES (@NomeJogo, @Descricao, @DataLancamento, @Valor, @IdEstudio)";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@NomeJogo", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será deletado</param>
        public void Deletar(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @ID";

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
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Retorna uma lista de jogos</returns>
        public List<JogoDomain> Listar()
        {
            // Cria uma lista jogos onde serão armazenados os dados
            List<JogoDomain> jogos = new List<JogoDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT J.IdJogo, E.IdEstudio, E.NomeEstudio, J.NomeJogo, J.Descricao, J.DataLancamento, J.Valor FROM Jogo J INNER JOIN Estudio E ON J.IdEstudio = E.IdEstudio";

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
                        // Instancia um objeto jogo 
                        JogoDomain jogo = new JogoDomain
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdJogo = Convert.ToInt32(rdr["IdJogo"])
                            ,
                            NomeJogo = rdr["NomeJogo"].ToString()
                            ,
                            Descricao = rdr["Descricao"].ToString()
                            ,
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"])
                            ,
                            Valor = Convert.ToDouble(rdr["Valor"])
                            ,
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"])
                            ,
                            Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"])
                                ,
                                NomeEstudio = rdr["NomeEstudio"].ToString()
                            }
                        };

                        // Adiciona o usuario criado à lista usuarios
                        jogos.Add(jogo);
                    }
                }
            }

            // Retorna a lista de usuários
            return jogos;
        }

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será atualizado</param>
        /// <param name="JogoAtualizado">Objeto JogoAtualizado que será alterado</param>
        public void Atualizar(int id, JogoDomain JogoAtualizado)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Jogo " +
                                     "SET NomeJogo = @NomeJogo, Descricao = @Descricao, DataLancamento = @DataLancamento, Valor = @Valor, IdEstudio = @IdEstudio " +
                                     "WHERE IdJogo = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NomeJogo", JogoAtualizado.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", JogoAtualizado.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", JogoAtualizado.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", JogoAtualizado.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", JogoAtualizado.IdEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
