using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SpMedical_webAPI.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consultum>();
        }

        public short IdSituacao { get; set; }
        public string TipoSituacao { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
