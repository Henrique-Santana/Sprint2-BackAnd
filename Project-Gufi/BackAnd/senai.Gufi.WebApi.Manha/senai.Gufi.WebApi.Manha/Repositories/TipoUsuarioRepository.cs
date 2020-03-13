using senai.Gufi.WebApi.Manha.Domains;
using senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Gufi.WebApi.Manha.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            //Cria um TIpo usuario chamado tipousuariobuscado e o tipousuario pssado pelo id sera armazenado nele.
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            //aqui estamos falando que as informações do tipoUsuarioBuscado é a mesmas de tipoUsuarioAtualizado. 
            tipoUsuarioBuscado.Titulo = tipoUsuarioAtualizado.Titulo;

            //Damos o comando Update para atualizar.
            ctx.TipoUsuario.Update(tipoUsuarioBuscado);

            //salvamos.
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.FirstOrDefault(tu => tu.IdTipoUsuario == id);

            return (tipoUsuarioBuscado);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuario.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoUsuario.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
