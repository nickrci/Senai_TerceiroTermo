using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SpMedical_webAPI.Domains
{
    public partial class EspecialidadeMedico
    {
        public EspecialidadeMedico()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdEspecialidadeMedico { get; set; }
        public string NomeEspecialidade { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
