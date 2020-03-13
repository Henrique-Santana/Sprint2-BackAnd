using senai.Gufi.WebApi.Manha.Domains;
using senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Gufi.WebApi.Manha.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository 
    {

        GufiContext ctx = new GufiContext();


        public void Atualizar(int id, Instituicao instituicaoAtualizado)
        {
            Instituicao instituicaoBuscado = ctx.Instituicao.FirstOrDefault(I => I.IdInstitucao == id);
            if (instituicaoAtualizado != null)
            {

                instituicaoBuscado.Cnpj = instituicaoAtualizado.Cnpj;
                instituicaoBuscado.Endereco = instituicaoAtualizado.Endereco;
                instituicaoBuscado.NomeFantasia = instituicaoAtualizado.NomeFantasia;
            }
            ctx.Instituicao.Update(instituicaoBuscado);

            ctx.SaveChanges();
        }

        public Instituicao BuscarPorId(int id)
        {
            return ctx.Instituicao.FirstOrDefault(i => i.IdInstitucao == (id));
        }

        public void Cadastrar(Instituicao novoInstituicao)
        {
            ctx.Instituicao.Add(novoInstituicao);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Instituicao.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
            return ctx.Instituicao.ToList();
        }
    }
}
