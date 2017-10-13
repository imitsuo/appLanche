using System;
using System.Collections.Generic;
using appLanche.Domain;

namespace appLanche.Web.Models
{
    public class MontarPedidoModel
    {
        public MontarPedidoModel()
        {
            this.IngredientesRemovidos = new List<string>();
            this.IngredientesAdicionais = new List<string>();
        }
        public string LancheId { get; set; }

        public List<string> IngredientesRemovidos {get; set;}

        public List<string> IngredientesAdicionais {get; set;}
    
    }
}