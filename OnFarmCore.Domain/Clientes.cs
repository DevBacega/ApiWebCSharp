using System;
using System.Collections.Generic;

namespace OnFarmCore.Domain
{
    public partial class Clientes
    {
        public Clientes()
        {
            Pedidos = new HashSet<Pedidos>();
        }

        public int IdCliente { get; set; }
        public string NmCliente { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int? Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Telefone { get; set; }

        public ICollection<Pedidos> Pedidos { get; set; }
    }
}
