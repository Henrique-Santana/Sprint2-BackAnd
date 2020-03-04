using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Jogo
    /// </summary>
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        // Define que o Nome é obrigatório
        [Required(ErrorMessage = "Informe o Nome do jogo")]
        public string NomeJogo { get; set; }
        
        public string Descricao { get; set; }

        // Define que a data é obrigatório
        [Required(ErrorMessage = "Informe o Data de lançamento do jogo")]
        // Define o tipo de dado
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        // Define que o Valor do jogo é obrigatório
        [Required(ErrorMessage = "Informe quanto vai custar o jogo")]
        public double Valor { get; set; }

        // Define que o Estudio é obrigatório
        [Required(ErrorMessage = "Informe o estudio responsável pelo jogo")]
        public int IdEstudio { get; set; }

        public EstudioDomain Estudio { get; set; }

    }
}
