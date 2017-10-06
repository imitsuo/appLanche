using System;
using System.Linq;

namespace appLanche.Domain
{
    public class CalculaPromocaoLigth : CalculaPromocao, ICalculaPromocao
    {
        public CalculaPromocaoLigth(Promocao promocao) : base(promocao)
        {
        }

        public override decimal CalculaDesconto(ItemDoPedido item)
        {
            if(item.IngredientesAdicionais.Any(i => i.Id == Promocao.IngredienteObrigatorio.Id) &&
                (
                    item.IngredientesRemovidos.Any(i => i.Id == Promocao.IngredienteRemovido.Id) ||
                    !item.Item.Ingredientes.Any( i => i.Id == Promocao.IngredienteRemovido.Id) 
                )
            )
            {
                return item.Valor * Promocao.PercentualDesconto;
            }

            return 0;

        }
    }
}
