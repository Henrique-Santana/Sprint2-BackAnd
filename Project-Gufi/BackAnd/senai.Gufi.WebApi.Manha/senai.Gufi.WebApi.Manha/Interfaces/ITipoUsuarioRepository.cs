using senai.Gufi.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Gufi.WebApi.Manha.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        void Cadastrar(TipoUsuario novoTipoUsuario);

        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);

        void Deletar(int id);

        TipoUsuario BuscarPorId(int id);
    }
}
