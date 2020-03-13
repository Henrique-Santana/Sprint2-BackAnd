using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Gufi.WebApi.Manha.Domains;
using senai.Gufi.WebApi.Manha.Interfaces;
using senai.Gufi.WebApi.Manha.Repositories;

namespace senai.Gufi.WebApi.Manha.Controller
{
    [Produces("Application//json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository { get; set; }

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_instituicaoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_instituicaoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Instituicao novoInstituicao)
        {
            _instituicaoRepository.Cadastrar(novoInstituicao);

            return Ok("Cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put (int id, Instituicao instituicaoAtualizado)
        {
            try
            {
                _instituicaoRepository.Atualizar(id, instituicaoAtualizado);

                return Ok("Instituicao Atualizada");
            }

            catch(Exception error)
            {
                return BadRequest(error);
            } 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _instituicaoRepository.Deletar(id);

            return Ok("Deletado ");
        }
    }
}