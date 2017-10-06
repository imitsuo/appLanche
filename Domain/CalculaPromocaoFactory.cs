using System;

namespace appLanche.Domain
{
    public class CalculaPromocaoFactory
    {
        public ICalculaPromocao Criar(Promocao promo)
        {
            switch(promo.Tipo)
            {
                case TipoPromocao.Light :
                    return new CalculaPromocaoLigth(promo);
                case TipoPromocao.MuitoMais :
                    return new CalculaPromocaoMuitoMais(promo);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
