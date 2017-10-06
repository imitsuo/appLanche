
using System.Collections.Generic;
using appLanche.Domain;

namespace appLanche.Services
{
    public interface IPedidoService
    {
        List<Lanche> ListarLanches();        
        List<Ingrediente> ListarIngredientes();        
        ItemDoPedido GerarPedido(ItemDoPedido item);        
    }
}