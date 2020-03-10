using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senail.InLock.WebApi.Codefirst.Domain
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdJogo { get; set; }

        [Column(TypeName ="VARCHAR (100)")]
        [Required(ErrorMessage ="O nome do jogo é obrigatorio")]
        public string NomeJogo { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descriçao do jogo é obrigatorio")]
        public string Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatorio")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "DECIMAL (18,2)")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O Estudio è obrigatòrio")]
        public int IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        Estudio estudio { get; set; }
    }
}
