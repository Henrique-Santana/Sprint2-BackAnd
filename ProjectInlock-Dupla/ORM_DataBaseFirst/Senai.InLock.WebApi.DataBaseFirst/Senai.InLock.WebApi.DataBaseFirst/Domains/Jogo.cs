using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.InLock.WebApi.DataBaseFirst.Domains
{
    /// <summary>
    /// Classe que representa a entidade Jogo
    /// </summary>
    public partial class Jogo
    {
        public int IdJogo { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string NomeJogo { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A descrição do jogo é obrigatória!")]
        public string Descricao { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        // Define o tipo do dado
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O preço do jogo é obrigatório!")]
        public decimal Valor { get; set; }
        public int? IdEstudio { get; set; }

        public Estudio IdEstudioNavigation { get; set; }
    }
}
