using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
 /// <summary>
 /// Interface responsável pelo repositório Filme
 /// </summary>
    interface IFilmeRepository
    {
        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Retorna uma lista de filmes</returns>
        List<FilmeDomain> Listar();


        /// <summary>
        /// Busca um filme através do ID
        /// </summary>
        /// <param name="id">ID do filme que será buscado</param>
        /// <returns>Retorna um filme</returns>
        FilmeDomain BuscarPorId(int id);
    }
}
