using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senail.InLock.WebApi.Codefirst.Domain
{
    [Table("Estudio")]
    public class Estudio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstudio { get; set; }

        [Column(TypeName = "VARCHAR (150)")]
        [Required(ErrorMessage ="O nome do estudio é obrigtorio")]
        public string NomeEstudio { get; set; }

        public List<Jogo> Jogos { get; set; }
    }
}
