using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace OnFarmCore.Domain
{
    public partial class Pedidos
    {
        public int IdPedido { get; set; }
        public int? IdCliente { get; set; }
        public string CodRastreio { get; set; }

        [NotMapped]
        public string DtCriacao { get; set; }

 
        [IgnoreDataMember]
        public Clientes IdClienteNavigation { get; set; }
    }
}
