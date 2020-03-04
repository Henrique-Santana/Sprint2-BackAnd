using senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os TipoUsuario
        /// </summary>
        /// <returns>Retorna uma lista de TipoUsuario</returns>
        List<TipoUsuarioDomain> Listar();

        /// <summary>
        /// Busca um Tipo de Usuario através do ID
        /// </summary>
        /// <param name="id">ID do Tipo que será buscado</param>
        /// <returns>Retorna um Tipo buscado</returns>
        TipoUsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// Atualiza um Tipo do usuario existente
        /// </summary>
        /// <param name="id">ID do Tipo que será atualizado</param>
        /// <param name="TipoUsuarioAtualizado">Objeto TipoUsuarioAtualizado que será atualizado</param>
        void Atualizar(int id, TipoUsuarioDomain TipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um Tipo de usuario existente
        /// </summary>
        /// <param name="id">ID do Tipo que será deletado</param>
        void Deletar(int id);

    }
}