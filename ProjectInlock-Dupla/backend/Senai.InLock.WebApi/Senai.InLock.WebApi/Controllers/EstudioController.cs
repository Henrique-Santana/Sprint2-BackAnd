using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos estudios
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    
    public class EstudioController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _estudioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IEstudioRepository _estudioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns>Retorna uma lista de estudios</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudioRepository.Listar());
        }

        /// <summary>
        /// Busca um estudio através do ID
        /// </summary>
        /// <param name="id">ID do estudio que será buscado</param>
        /// <returns>Retorna um estudio buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudioDomain EstudioBuscado = _estudioRepository.BuscarPorId(id);
            if (EstudioBuscado != null)
            {
                return Ok(EstudioBuscado);
            }

            return NotFound("Nenhum Estudio encontrado");
        }

        /// <summary>
        /// Deleta um estudio existente
        /// </summary>
        /// <param name="id">ID do estudio que será deletado</param>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EstudioDomain EstudioBuscado = _estudioRepository.BuscarPorId(id);

            if (EstudioBuscado != null)
            {
                _estudioRepository.Deletar(id);

                return Ok($"O Estudio {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum Estudio encontrado");
        }

        /// <summary>
        /// Cadastra um novo estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            if (novoEstudio.NomeEstudio == null)
            {
                return BadRequest("O nome do Estudio é obrigatório!");
            }
            _estudioRepository.Cadastrar(novoEstudio);

            return Created("http://localhost:5000/api/Estudio", novoEstudio);
        }

        /// <summary>
        /// Atualiza um estudio existente
        /// </summary>
        /// <param name="id">ID do estudio que será atualizado</param>
        /// <param name="estudioAtualizado">Objeto EstudioAtualizado que será alterado</param>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, EstudioDomain estudioAtualizado)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);
            if (estudioBuscado != null)
            {
                try
                {
                    _estudioRepository.Atualizar(id, estudioAtualizado);
                    return Ok($"Estudio {id} atualizado com sucesso!");
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound
                (
                    new
                    {
                        mensagem = "Estudio não encontrado",
                        erro = true
                    }
                );
        }
    }
}
