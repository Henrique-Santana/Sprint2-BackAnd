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
    [Route("api/[controller]")]
    [ApiController]

    
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogorepository;

        public JogoController()
        {
            _jogorepository = new JogoRepository();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Retorna uma lista de jogos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogorepository.Listar());
        }

        /// <summary>
        /// Busca um jogo através do ID
        /// </summary>
        /// <param name="id">ID do jogo que será buscado</param>
        /// <returns>Retorna um jogo buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogoDomain jogoBuscado = _jogorepository.BuscarPorId(id);
            if (jogoBuscado != null)
            {
                return Ok(jogoBuscado);
            }

            return NotFound("Nenhum Jogo encontrado");
        }

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será deletado</param>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            JogoDomain jogoBuscado = _jogorepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                _jogorepository.Deletar(id);

                return Ok($"O Jogo {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum Jogo encontrado");
        }

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">Objeto JogoAtualizado que será alterado</param>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, JogoDomain jogoAtualizado)
        {
            JogoDomain jogoBuscado = _jogorepository.BuscarPorId(id);
            if (jogoBuscado != null)
            {
                try
                {
                    _jogorepository.Atualizar(id, jogoAtualizado);
                    return Ok($"Jogo {id} atualizado com sucesso!");
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
                        mensagem = "Jogo não encontrado",
                        erro = true
                    }
                );
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="NovoJogo">Objeto novoJogo que será cadastrado</param>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogoDomain NovoJogo)
        {
            if (NovoJogo.NomeJogo == null)
            {
                return BadRequest("O nome do Jogo é obrigatório!");
            }
            _jogorepository.Cadastrar(NovoJogo);

            return Ok("Jogo cadastrado com sucesso!");
        }
    }
}
