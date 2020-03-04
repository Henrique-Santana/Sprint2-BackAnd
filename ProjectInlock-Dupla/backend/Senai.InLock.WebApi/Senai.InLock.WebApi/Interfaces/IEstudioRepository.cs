using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório Estudio
    /// </summary>
    interface IEstudioRepository
    {
        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns>Retorna uma lista de estudios</returns>
        List<EstudioDomain> Listar();

        /// <summary>
        /// Busca um estudio através do ID
        /// </summary>
        /// <param name="id">ID do estudio que será buscado</param>
        /// <returns>Retorna um estudio buscado</returns>
        EstudioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Atualiza um estudio existente
        /// </summary>
        /// <param name="id">ID do estudio que será atualizado</param>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado que será atualizado</param>
        void Atualizar(int id, EstudioDomain estudioAtualizado);

        /// <summary>
        /// Deleta um estudio existente
        /// </summary>
        /// <param name="id">ID do estudio que será deletado</param>
        void Deletar(int id);

    }
}
