using senai.Gufi.WebApi.Manha.Domains;
using senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Gufi.WebApi.Manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        GufiContext ctx = new GufiContext();


        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            if (usuarioAtualizado != null)
            {
                usuarioBuscado.DataCasdastro = usuarioAtualizado.DataCasdastro;
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Genero = usuarioAtualizado.Genero;
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
                usuarioBuscado.Nome = usuarioAtualizado.Nome;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuario.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(i => i.IdUsuario == id);

        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuario.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }
    }
}
