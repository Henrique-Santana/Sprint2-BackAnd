using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório Usuario
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Retorna uma lista de usuários</returns>
        List<Usuario> List();

        /// <summary>
        /// Busca um usuário através do Id
        /// </summary>
        /// <param name="id">id do usuário que será buscado</param>
        /// <returns>Retorna o usuário buscado</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">Id do jogo que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto que vai receber o usuario atualizado</param>
        void Atualizar(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="id">Id do usuario que será deletado</param>
        void Deletar(int id);
    }
}
