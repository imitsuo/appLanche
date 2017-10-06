using System;

namespace appLanche.Domain
{
    public abstract class CalculaPromocao : ICalculaPromocao
    {
        public Promocao Promocao {get; protected set;}
        
        public CalculaPromocao(Promocao promocao)
        {
            this.Promocao = promocao;
        }
        public virtual decimal CalculaDesconto(ItemDoPedido item)
        {
            throw new NotImplementedException();
        }
    }
}
