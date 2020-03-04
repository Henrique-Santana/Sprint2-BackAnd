using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Tipo de Usuario
    /// </summary>
    public class TipoUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }

        // Define que o informar o Tipo de usuario é obrigatório
        [Required(ErrorMessage = "Informe o Tipo do usuário")]
        public string Titulo { get; set; } 
    }
}
