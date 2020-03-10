using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senail.InLock.WebApi.Codefirst.Domain
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        //define que sera uma chave primaria
        [Key]
        //define o auto-incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoUsuario { get; set; }

        //define o tipo de dado
        [Column(TypeName = "VARCHAR (255)")]
        //define que a propriedade é obrigatório
        [Required(ErrorMessage = "O titulo do tipo de usuario é obrigtorio")]
        public string Titulo { get; set; }
    }
}
