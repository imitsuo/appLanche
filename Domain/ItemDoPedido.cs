using System;
using System.Collections.Generic;
using System.Linq;

namespace appLanche.Domain
{
    public class ItemDoPedido
    {
        public int Id {get; protected set;}

        public decimal Valor {
            get{
                return 
                 (Item.Valor + IngredientesAdicionais.Sum(i => i.Valor))  
                 - IngredientesRemovidos.Sum(i => i.Valor);
            } 
        }

        public decimal ValorTotal {
            get{
                return 
                 (Item.Valor + IngredientesAdicionais.Sum(i => i.Valor))  
                 - IngredientesRemovidos.Sum(i => i.Valor)
                 - Descontos.Sum(d => d.Valor);
            } 
        }
        
        public Lanche Item {get; protected set;}

        public List<Ingrediente> IngredientesAdicionais{get; protected set;}

        public List<Ingrediente> IngredientesRemovidos{get; protected set;}
        public List<Desconto> Descontos {get; protected set;}
        private ItemDoPedido()
        {}

        public ItemDoPedido(Lanche item)
        {
            this.IngredientesAdicionais = new List<Ingrediente>();
            this.IngredientesRemovidos = new List<Ingrediente>();
            this.Descontos = new  List<Desconto>();
            this.Item = item;
        }

        public void AdicionarIngrediente(Ingrediente ingrediente)
        {
            this.IngredientesAdicionais.Add(ingrediente);
        }

        public void RemoverIngrediente(Ingrediente ingrediente)
        {
            if(!this.Item.Ingredientes.Any(i => i.Id == ingrediente.Id))
                throw new Exception("O Ingrediente a Ser Removido nao pertence ao Lanche !");

            if(IngredientesRemovidos.Any(i => i.Id == ingrediente.Id))
                throw new Exception("O Ingrediente nao Removido mais de uma vez !");


            IngredientesRemovidos.Add(ingrediente);
        }

        public void AdicionarDesconto(decimal valor, Promocao promo)
        {
            this.Descontos.Add(new Desconto(promo, valor));
        }
    }
}
