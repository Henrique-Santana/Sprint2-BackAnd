using senai.Gufi.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Gufi.WebApi.Manha.Interfaces
{
    interface IInstituicaoRepository
    {
        List<Instituicao> Listar();

        void Cadastrar (Instituicao novoInstituicao);

        void Atualizar(int id, Instituicao instituicaoAtualizado);

        void Deletar (int id);

        Instituicao BuscarPorId (int id);
    }
}
