using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SpMedical_webAPI.Domains
{
    public partial class Consultum
    {
        public short IdConsulta { get; set; }
        public short IdCliente { get; set; }
        public short IdMedico { get; set; }
        public short IdSituacao { get; set; }
        public DateTime DataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
