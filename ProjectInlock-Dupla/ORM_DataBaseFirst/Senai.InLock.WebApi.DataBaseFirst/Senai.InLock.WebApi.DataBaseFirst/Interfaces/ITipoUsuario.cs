using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    /// <summary>
    /// Interface responsável pelo TipoUsuarioRepository
    /// </summary>
    interface ITipoUsuario
    {
        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Retorna uma lista com os tipos de usuarios</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Busca um tipo de usuario através do Id
        /// </summary>
        /// <param name="id">Id do tipo de usuario que será buscado</param>
        /// <returns>Retorna o tipo de usuario buscado</returns>
        TipoUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto que receberá o novoTipoUsuario</param>
        void Cadastrar(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um tipo de usuario existente
        /// </summary>
        /// <param name="id">Id do Tipo de usuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto que receberá o tipo de usuario atualizado</param>
        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um tipo de usuario
        /// </summary>
        /// <param name="id">Id do tipo de usuario que será deletado</param>
        void Deletar(int id);
    }
}
