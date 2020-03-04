using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório Jogo
    /// </summary>
    interface IJogoRepository
    {
        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Retorna uma lista de jogos</returns>
        List<JogoDomain> Listar();

        /// <summary>
        /// Busca um jogo através do ID
        /// </summary>
        /// <param name="id">ID do jogo que será buscado</param>
        /// <returns>Retorna um jogo buscado</returns>
        JogoDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">Objeto jogoAtualizado que será atualizado</param>
        void Atualizar(int id, JogoDomain jogoAtualizado);

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será deletado</param>
        void Deletar(int id);

    }
}
