using Microsoft.EntityFrameworkCore;
using senai.Inlock.WebApi.DataBaseFirst.Domains;
using senai.Inlock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Inlock.WebApi.DataBaseFirst.Repositories
{
    /// <summary>
    /// Repositorio responsavel pelos estudios
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        InlockContext ctx = new InlockContext();

        public void Atualizar(int id, Estudio estudioAtualizado)
        {
            // Busca um estúdio através do id
            Estudio estudioBuscado = ctx.Estudio.Find(id);

            // Atribui os novos valores ao campos existentes
            estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;

            // Atualiza o estúdio que foi buscado
            ctx.Estudio.Update(estudioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um estúdio através do ID
        /// </summary>
        /// <param name="id">ID do estúdio que será buscado</param>
        /// <returns>Um estúdio buscado</returns>
        public Estudio BuscarPorId(int id)
        {
            // Retorna o primeiro estúdio encontrado para o ID informado
            return ctx.Estudio.FirstOrDefault(e => e.IdEstudio == id);
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        public void Cadastrar(Estudio novoEstudio)
        {
            // Adiciona este novoEstudio
            ctx.Estudio.Add(novoEstudio);
            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um estúdio através do id
            Estudio estudioBuscado = ctx.Estudio.Find(id);

            // Remove o estúdio que foi buscado
            ctx.Estudio.Remove(estudioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios</returns>
        public List<Estudio> Listar()
        {
            // Retorna uma lista com todas as informações dos estúdios
            return ctx.Estudio.ToList();
        }

        public List<Estudio> ListarJogos()
        {
            // Retorna uma lista de estúdios com seus jogos
            return ctx.Estudio.Include(e => e.Jogo).ToList();
        }
    }
}
