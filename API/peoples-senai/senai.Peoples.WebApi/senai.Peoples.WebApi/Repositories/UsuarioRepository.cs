using senai.Peoples.WebApi.Domains;
using senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string stringConexao = "Data Source=DEV17\\SQLEXPRESS; initial catalog=Peoples_manha; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Atualiza um Usuario existente
        /// </summary>
        /// <param name="id">ID do Usuario que será atualizado</param>
        /// <param name="UsuarioAtualizado">Objeto UsuarioAtualizado que será atualizado</param>
        public void Atualizar(int id, UsuarioDomain UsuarioAtualizado)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Usuario " +
                                     "SET Email = @Email, Senha= @Senha, IdTipoUsuario= @IdTipoUsuario " +
                                     "WHERE IdFuncionario = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Email", UsuarioAtualizado.Email);
                    cmd.Parameters.AddWithValue("@Senha", UsuarioAtualizado.Senha);
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", UsuarioAtualizado.IdTipoUsuario);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um Usuario através do ID
        /// </summary>
        /// <param name="id">ID do Usuario que será buscado</param>
        /// <returns>Retorna um Usuario buscado</returns>
        public UsuarioDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById ="SELECT IdUsuario, Email, Usuario.IdTipoUsuario, TipoUsuario.Titulo FROM Usuario" +
                                        " INNER JOIN TipoUsuario" +
                                        " ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario" +
                                        " WHERE IdUsuario = @ID";

                                       //"SELECT IdUsuario, Email, Senha, DataNascimento FROM Funcionarios" +
                                       //" WHERE IdFuncionario = @ID";

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
                        // Instancia um objeto Usuario 
                        UsuarioDomain Usuario = new UsuarioDomain
                        {
                            // Atribui à propriedade IdUsuario o valor da coluna "IdUsuario" da tabela do banco
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"])

                            // Atribui à propriedade Email o valor da coluna "Email" da tabela do banco
                            ,
                            Email = rdr["Email"].ToString()

                            // Atribui à propriedade Senha o valor da coluna "Senha" da tabela do banco
                            ,
                            Senha = rdr["Senha"].ToString()

                            // Atribui à propriedade IdUsuario o valor da coluna "IdUsuario" da tabela do banco
                            ,
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])
                            ,
                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])
                                ,
                                Titulo = rdr["Titulo"].ToString()
                            }
                        };

                        // Retorna o Usuario buscado
                        return Usuario;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO Usuario(Email, Senha, IdTipoUsuario) " +
                                     "VALUES (@Email, @Senha, @IdTipoUsuario)";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", novoUsuario.IdTipoUsuario);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            // Declara a conexão passando a string de conexão POR @ID
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Usuario WHERE IdUsuario = @ID";

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

        public List<UsuarioDomain> Listar()
        {
            //Cria uma lista para armazenar os Dados(usuarios)
            List<UsuarioDomain> Usuarios = new List<UsuarioDomain>();

            //Declara a SqlConnection passando a stringConexao  
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a string de Instrução do método
                string querySelecAll = "SELECT IdUsuario, Email, Senha, TipoUsuario.IdTipoUsuario, IdTipoUsuario.Titulo FROM Usuario" +
                                       "INNER JOIN TipoUsuario" +
                                       "ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario";
                //Declara a Conexão com o BD
                con.Open();

                //Declara o SqlDataReader Para receber os dados do banco'No cado os usuario'
                SqlDataReader rdr;

                //Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelecAll, con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Lupe Para enquanto tiver Usuarios para serem lidos ele se Repete
                    while (rdr.Read())
                    {
                        //Instacia um objeto Usuario do Tipo Domain
                        UsuarioDomain Usuario = new UsuarioDomain
                        {
                            //Atribui á propriedade IdUsuario ao valor da coluna IdUsuairo na tabela Usuario do banco 
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"])

                            //Atribui á propriedade Email ao valor da coluna Email na tabela Usuario do banco
                            , Email = rdr["Email"].ToString()

                            //Atribui á propriedade Senha ao valor da coluna Senha na tabela Usuario do banco
                            , Senha = rdr["Senha"].ToString()

                            //Atribui á propriedade IdTipoUsuario ao valor da coluna IdTipoUsuario na tabela Usuario do banco
                            , IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])

                            ,
                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])

                                ,Titulo = rdr["Titulo"].ToString()
                            }
                        };
                        // Adiciona o Usuario criado à lista Usuarios
                        Usuarios.Add(Usuario);
                    }
                }
            }//Retornar a Lista dos Usuarios Listados
            return Usuarios;
        }

        /// <summary>
        /// Lista todos os Usuarioa de maneira ordenada pelo Email
        /// </summary>
        /// <param Email="ordem">String que define a ordenação (crescente ou descrescente)</param>
        /// <returns>Retorna uma lista ordenada de Usuarios</returns>
        public List<UsuarioDomain> ListarOrdenado(string ordem)
        {
            // Cria uma lista Usuarios onde serão armazenados os dados
            List<UsuarioDomain> Usuarios = new List<UsuarioDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdUsuario, Email, Senha, IdTipoUsuario " +
                                        $"FROM Usuarios ORDER BY Email {ordem}";

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
                        // Instancia um objeto Usuario 
                        UsuarioDomain Usuario = new UsuarioDomain
                        {
                            // Atribui à propriedade IdUsuario o valor da coluna "IdUsuario" da tabela do banco
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"])

                            // Atribui à propriedade Email o valor da coluna "Email" da tabela do banco
                            ,
                            Email = rdr["Email"].ToString()

                            // Atribui à propriedade Senha o valor da coluna "Senha" da tabela do banco
                            ,
                            Senha = rdr["Senha"].ToString()

                            // Atribui à propriedade IdTipoUsuario o valor da coluna "IdTipoUsuario" da tabela do banco
                            ,
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])
                        };

                        // Adiciona o Usuario criado à lista Usuarios
                        Usuarios.Add(Usuario);
                    }
                }
            }

            // Retorna a lista de Usuarios
            return Usuarios;
        }
    }
}
