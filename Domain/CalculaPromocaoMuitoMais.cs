using System;
using System.Linq;

namespace appLanche.Domain
{
    public class CalculaPromocaoMuitoMais : CalculaPromocao, ICalculaPromocao
    {
        public CalculaPromocaoMuitoMais(Promocao promocao) : base(promocao)
        {
        }

        public override decimal CalculaDesconto(ItemDoPedido item)
        {
            var ingrAdicionais = item.IngredientesAdicionais.Where(i => i.Id == Promocao.IngredienteAdicional.Id).ToList();
            ingrAdicionais.AddRange(item.Item.Ingredientes.Where(i => i.Id == Promocao.IngredienteAdicional.Id));

            if(ingrAdicionais.Any() && 
               ingrAdicionais.Count / Promocao.QuantidadeDeItens > 0) 
               {
                   int qtdDesconto = (int)(ingrAdicionais.Count / Promocao.QuantidadeDeItens);

                   return qtdDesconto * Promocao.IngredienteAdicional.Valor;
               }                

            
            return 0;            
        }
    }
}
