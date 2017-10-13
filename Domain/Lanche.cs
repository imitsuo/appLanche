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
                return Ingredientes.Select(x => x == null ? 0 : x.Valor).Sum();
            }
        }

        public virtual List<Ingrediente> Ingredientes {
            get
            {
                return IngredienteLanche.Select(x => x.Ingrediente).ToList();
            }
        }

        public List<IngredienteLanche> IngredienteLanche {get; protected set;}

        public string DescricaoIngredientes()
        {            
            return this.Ingredientes.Any() 
            ? string.Join(", ", this.Ingredientes.Select(i => i.Nome))
            : string.Empty;
        }

        private Lanche()
        {
            this.IngredienteLanche = new List<IngredienteLanche>();
        }

        public Lanche(int id, string nome, List<Ingrediente> ingredientes)
        {
            this.IngredienteLanche = new List<IngredienteLanche>();
            this.Id = id;
            this.Nome = nome;            
            AdicionarIngredientes(ingredientes);
        }

        public Lanche(string nome, List<Ingrediente> ingredientes)
        {    
            this.IngredienteLanche = new List<IngredienteLanche>();        
            this.Nome = nome;
            AdicionarIngredientes(ingredientes);
            //this.Ingredientes = ingredientes;
        } 

        public void AdicionarIngrediente(Ingrediente ingrediente)
        {
            if(!IngredienteLanche.Where(x => x.Ingrediente.Id == ingrediente.Id).Any())
                this.IngredienteLanche.Add(new IngredienteLanche(this, ingrediente));
        }
        private void AdicionarIngredientes(List<Ingrediente> ingredientes)
        {
            ingredientes.ForEach(i => this.AdicionarIngrediente(i));
        }   
    }
}
