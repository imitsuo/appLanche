using System;
using System.Collections.Generic;

namespace appLanche.Domain
{
    public class Desconto
    {
        public int Id {get; protected set;}

        public Promocao Promocao {get; protected set;}

        public decimal Valor {get; protected set;}
                
        //public List<IngredienteLanche> IngredienteLanche {get; protected set;}
        private Desconto()
        {}
        
        public Desconto(Promocao promo, decimal valor)
        {            
            this.Valor = valor;
            this.Promocao = promo;
        }

    }
}
