using System;
using System.Collections.Generic;
using System.Linq;

namespace appLanche.Domain
{
    public class Lanche
    {
        public int Id {get; protected set;}

        public string Nome {get; protected set;}

        public decimal Valor 
        {
            get
            {
                return Ingredientes.Select(x => x.Valor).Sum();
            }
        }

        public List<Ingrediente> Ingredientes {get; protected set;}       

        private Lanche()
        {}
        public Lanche(string nome, List<Ingrediente> ingredientes)
        {
            //this.Id = id;
            this.Nome = nome;            
            this.Ingredientes = ingredientes;
        }        
    }
}
