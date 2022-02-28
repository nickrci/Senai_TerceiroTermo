using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SpMedical_webAPI.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consultum>();
        }

        public short IdMedico { get; set; }
        public short IdUsuario { get; set; }
        public short IdEspecialidadeMedico { get; set; }
        public short IdClinica { get; set; }
        public string CrmMedico { get; set; }
        public string NomeMedico { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual EspecialidadeMedico IdEspecialidadeMedicoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
