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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return Ok("Cadastrado com sucesso");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

                return Ok("Atualizado");
            }

            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Detele (int id)
        {
            _tipoUsuarioRepository.Deletar(id);

            return Ok("Tipo Usuario Deletado");
        }
    }
}