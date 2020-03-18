using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.InLock.WebApi.DataBaseFirst.Domains
{
    public partial class Estudio
    {
        /// <summary>
        /// Classe que representa a entidade Estudio
        /// </summary>
        public Estudio()
        {
            Jogo = new HashSet<Jogo>();
        }

        public int IdEstudio { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do estúdio é obrigatório!")]
        public string NomeEstudio { get; set; }

        public ICollection<Jogo> Jogo { get; set; }
    }
}
