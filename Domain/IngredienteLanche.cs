using System;
using System.Collections.Generic;

namespace appLanche.Domain
{
    public class IngredienteLanche
    {
        public int LancheId {get; protected set;}

        public int IngredienteId {get; protected set;}

        public Lanche Lanche {get; protected set;}

        public Ingrediente Ingrediente {get; protected set;}
        
        private IngredienteLanche()
        {}

        public IngredienteLanche(Lanche lanche, Ingrediente ingrediente)
        {
            this.Lanche = lanche;
            this.LancheId = lanche.Id;

            this.Ingrediente = ingrediente;
            this.IngredienteId = ingrediente.Id;
        }
        
       
    }
}
