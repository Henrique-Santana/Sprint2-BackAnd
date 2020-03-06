using senai.Inlock.WebApi.DataBaseFirst.Domains;
using senai.Inlock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Inlock.WebApi.DataBaseFirst.Repositories
{
    /// <summary>
    /// Repositório dos Estúdios
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        InlockContext ctx = new InlockContext();

        public void Atualizar(int id, Usuario UsuarioAtualizado)
        {
            //
            Usuario UsuarioBuscado = ctx.Usuario.FirstOrDefault(e => e.IdUsuario == id);

            UsuarioBuscado.Email = UsuarioAtualizado.Email;
            UsuarioBuscado.Senha = UsuarioAtualizado.Senha;
            UsuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;

            //
            ctx.Usuario.Update(UsuarioBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();

        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            ctx.Usuario.FirstOrDefault(e => e.Email == email);

            return ctx.Usuario.FirstOrDefault(e => e.Senha == senha);

        }

        /// <summary>
        /// Busca um usuario pelo id
        /// </summary>
        /// <param name="id">Id do usuario que sera buscado</param>
        /// <returns></returns>
        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(e => e.IdUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            // Adiciona este novoUsuairo
            ctx.Usuario.Add(novoUsuario);
            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //Procura o usuario informado pelo id
            Usuario UsuarioDeletado = ctx.Usuario.FirstOrDefault(e => e.IdUsuario == id);

            //Deleta o usuario
            ctx.Usuario.Remove(UsuarioDeletado);

            //Salva a alteração
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Usuario
        /// </summary>
        /// <returns>Uma lista de Usuario</returns>
        public List<Usuario> Listar()
        {
            // Retorna uma lista com todas as informações dos Usuario
            return ctx.Usuario.ToList();
        }
    }
}
