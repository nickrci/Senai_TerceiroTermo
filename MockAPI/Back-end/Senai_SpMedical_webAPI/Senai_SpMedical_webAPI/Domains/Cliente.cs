using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SpMedical_webAPI.Domains
{
    public partial class Cliente
    {
        public Cliente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public short IdCliente { get; set; }
        public short IdUsuario { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataNascCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public string RgCliente { get; set; }
        public string CpfCliente { get; set; }
        public string EnderecoCliente { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
