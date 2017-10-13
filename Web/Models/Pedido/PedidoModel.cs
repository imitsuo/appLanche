using System;
using System.Collections.Generic;
using appLanche.Domain;

namespace appLanche.Web.Models
{
    public class PedidoModel
    {
        public string RequestId { get; set; }

        public List<Lanche> Lanches {get; set;}

        public ItemDoPedido Item {get; set;}
    
    }
}