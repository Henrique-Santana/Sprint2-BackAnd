using senai.Gufi.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Gufi.WebApi.Manha.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar ();

        Usuario BuscarPorId (int id);

        void Cadastrar (Usuario novoUsuario);

        void Atualizar (int id, Usuario usuarioAtualizado);

        void Deletar(int id);
    }
}
