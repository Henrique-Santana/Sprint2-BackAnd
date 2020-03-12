﻿using System;
using System.Collections.Generic;

namespace senai.Gufi.WebApi.Manha.Domains
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Evento = new HashSet<Evento>();
        }

        public int IdEvento { get; set; }
        public string TituloTipoEvento { get; set; }

        public ICollection<Evento> Evento { get; set; }
    }
}
