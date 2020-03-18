using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.InLock.WebApi.DataBaseFirst.Domains
{
    /// <summary>
    /// Classe que representa a entidade TipoUsuario
    /// </summary>
    public partial class TipoUsuario
    {        
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O título do tipo de usuário é obrigatório!")]
        public string Titulo { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
