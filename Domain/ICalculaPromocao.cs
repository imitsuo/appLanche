using System;

namespace appLanche.Domain
{
    public interface ICalculaPromocao
    {        
        decimal CalculaDesconto(ItemDoPedido item);
    }    
}
