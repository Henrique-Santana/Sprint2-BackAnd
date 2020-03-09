using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senail.InLock.WebApi.Codefirst.Domain
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR (150)")]
        [Required(ErrorMessage ="O email do usuario é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR (150)")]
        [Required(ErrorMessage = "A senha do usuario é obrigatório")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Aa senha tem que ter no monimo 5 caracteres e no maximo 30")]
        public string Senha { get; set; }

        public int IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        TipoUsuario tipoUsuario { get; set; }
    }
}
