using senai.Gufi.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Gufi.WebApi.Manha.Interfaces
{
    interface ITipoEventoRepository
    {
        List<TipoEvento> Listar();

        void Cadastrar(TipoEvento novoTipoEvento);

        void Atualizar(int id, TipoEvento tipoEventoAtualizado);

        void Deletar(int id);

        TipoEvento BuscarPorId(int id);
    }
}
