using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    /// <summary>
    /// Interface responsável pelo JogoRepository
    /// </summary>
    interface IJogoRepository
    {
        /// <summary>
        /// Lista todo os jogos
        /// </summary>
        /// <returns>Retorna uma lista de jogos cadastrados</returns>
        List<Jogo> Listar();

        /// <summary>
        /// Busca um jogo pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o jogo buscado pelo id</returns>
        Jogo BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto que será armazenado o novo jogo</param>
        void Cadastrar(Jogo novoJogo);

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="id">Id do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">Objeto que será atualizado o jogo</param>
        void Atualizar(int id, Jogo jogoAtualizado);

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id">Id do jogo que será deletado</param>
        void Deletar(int id);
    }
}
