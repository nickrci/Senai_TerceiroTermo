using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SpMedical_webAPI.Domains
{
    public partial class Usuario
    {
        public short IdUsuario { get; set; }
        public short IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Medico Medico { get; set; }
    }
}
