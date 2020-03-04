using senai.Peoples.WebApi.Domains;
using senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source=DEV17\\SQLEXPRESS; initial catalog=Peoples_manha; user Id=sa; pwd=sa@132";


        public void Atualizar(int id, TipoUsuarioDomain TipoUsuarioAtualizado)
        {
                // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE TipoUsuario " +
                                        "SET Nome = @Titulo " +
                                        "WHERE IdTipoUsuario = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", TipoUsuarioAtualizado.Titulo);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um TipoUsuario através do ID
        /// </summary>
        /// <param name="id">ID do TipoUsuario que será buscado</param>
        /// <returns>Retorna um Tipo buscado</returns>
        public TipoUsuarioDomain BuscarPorId(int id)
        {
                // Declara a conexão passando a string de conexão
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    // Declara a query que será executada
                    string querySelectById = "SELECT IdTipoUsuario, Titulo FROM TipoUsuario" +
                                            " WHERE IdTipoUsuario = @ID";

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
                            // Instancia um objeto TipoUsuario 
                            TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                            {
                                // Atribui à propriedade IdTipoUsuario o valor da coluna "IdTipoUsuario" da tabela do banco
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])

                                // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                                ,
                                Titulo = rdr["Titulo"].ToString()
                            };

                            // Retorna o tipoUsuario buscado
                            return tipoUsuario;
                        }

                        // Caso o resultado da query não possua registros, retorna null
                        return null;
                    }
                }
            }


        /// <summary>
        /// Deleta um Tipo de Usuario existente
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM TipoUsuario WHERE IdTipoUsuario = @ID";

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
        /// Lista todos os Tipos de Usuario
        /// </summary>
        /// <returns>Retorna uma lista dos Tipos de Usuario</returns>
        public List<TipoUsuarioDomain> Listar()
        {
            // Cria uma lista TipoUsuario onde serão armazenados os dados (OS Tipos de Usuario)
            List<TipoUsuarioDomain> TiposUsuario = new List<TipoUsuarioDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdTipoUsuario, Titulo FROM TipoUsuario";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto TipoUsuario 
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {
                            // Atribui à propriedade IdTipoUsuario o valor da coluna "IdTipoUsuario" da tabela do banco
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])

                            // Atribui à propriedade Titulo o valor da coluna "Titulo" da tabela do banco
                            ,
                            Titulo = rdr["Titulo"].ToString()
                        };

                        // Adiciona o TipoUsuario criado à lista TiposUsuario
                        TiposUsuario.Add(tipoUsuario);
                    }
                }
            }
            // Retorna a lista de TiposUsuario
            return TiposUsuario;
        }
    }
}