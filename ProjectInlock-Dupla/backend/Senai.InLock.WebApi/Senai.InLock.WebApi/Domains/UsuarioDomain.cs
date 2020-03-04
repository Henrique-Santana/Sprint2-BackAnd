using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{

    /// <summary>
    /// Classe que representa a entidade Usuario
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        // Define que o e-mail é obrigatório
        [Required(ErrorMessage = "Informe o e-mail do usuário")]
        // Define o tipo do dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define que a senha é obrigatório
        [Required(ErrorMessage = "Informe a senha do usuário")]
        // Define o tipo do dado
        [DataType(DataType.Password)]
        // Define os requisitos da senha
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A senha deve conter no mínimo 5 e no máximo 30 caracteres")]
        public string Senha { get; set; }

        public int IdTipoUsuario { get; set; }

        public TipoUsuarioDomain TipoUsuario { get; set; }
    }
}
