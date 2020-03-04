using senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Retorna uma lista de Usuarios</returns>
        List<UsuarioDomain> Listar();

        /// <summary>
        /// Busca um Usuario através do ID
        /// </summary>
        /// <param name="id">ID do Usuario que será buscado</param>
        /// <returns>Retorna um Usuario buscado</returns>
        UsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        void Cadastrar(UsuarioDomain novoUsuario);

        /// <summary>
        /// Atualiza um Usuario existente
        /// </summary>
        /// <param name="id">ID do Usuario que será atualizado</param>
        /// <param name="UsuarioAtualizado">Objeto funcionarioAtualizado que será atualizado</param>
        void Atualizar(int id, UsuarioDomain UsuarioAtualizado);

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="id">ID do Usuario que será deletado</param>
        void Deletar(int id);


        /// <summary>
        /// Lista todos os Usuarios de maneira ordenada pelo nome
        /// </summary>
        /// <param name="ordem">String que define a ordenação (crescente ou descrescente)</param>
        /// <returns>Retorna uma lista ordenada de Usuarios</returns>
        List<UsuarioDomain> ListarOrdenado(string ordem);
    }
}
