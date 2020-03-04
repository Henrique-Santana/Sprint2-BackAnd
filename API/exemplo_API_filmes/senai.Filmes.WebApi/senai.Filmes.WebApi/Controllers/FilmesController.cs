using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;

namespace senai.Filmes.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos Filmes
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    public class FilmesController : ControllerBase
    {

        /// <summary>
        /// Cria um objeto _generoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }


        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        /// dominio/api/Generos
        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            // Faz a chamada para o método .Listar();
            return _filmeRepository.Listar();
        }

        /// <summary>
        /// Busca um filme através do seu ID
        /// </summary>
        /// <param name="id">ID do filme buscado</param>
        /// <returns>Retorna um filme buscado</returns>
        /// dominio/api/Filme/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

            // Verifica se nenhum gênero foi encontrado
            if (filmeBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 com a mensagem personalizada
                return NotFound("Nenhum filme encontrado");
            }

            // Caso seja encontrado, retorna o gênero buscado
            return Ok(filmeBuscado);
        }

    }
}