using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Senai.InLock.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Estudio
    /// </summary>
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }

        // Define que o nome do Estudio precisa ser informado
        [Required(ErrorMessage = "O nome do Estudio é obrigatório")]
        public string NomeEstudio { get; set; }
    }
}
