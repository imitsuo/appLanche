using System.Linq;
using System.Collections.Generic;
using appLanche.Domain;
using appLanche.Infrastructure;

namespace appLanche.Services
{
    public class PedidoService : IPedidoService
    {
        private IRepository<Lanche> LancheRepository;
        private IRepository<ItemDoPedido> ItemDoPedidoRepository;
        private IRepository<Ingrediente> IngredienteRepository;

        private IRepository<Promocao> PromocaoRepository;

        public PedidoService(IRepository<Lanche> lancheRepository,
                             IRepository<ItemDoPedido> itemDoPedidoRepository,
                             IRepository<Ingrediente> ingredienteRepository,
                             IRepository<Promocao> promocaoRepository
                            )
        {
            this.LancheRepository = lancheRepository;
            this.ItemDoPedidoRepository = itemDoPedidoRepository;
            this.IngredienteRepository = ingredienteRepository;
            this.PromocaoRepository = promocaoRepository;
        }
        public ItemDoPedido GerarPedido(ItemDoPedido item)
        {
            var promocoes = this.PromocaoRepository.GetAll().ToList();

            item.ValorTotal = item.Valor;

            promocoes.ForEach(p =>
            {
                var calculaDesconto = new CalculaPromocaoFactory()
                            .Criar(p);

                item.ValorTotal -= calculaDesconto.CalculaDesconto(item);
            });

            var ret = this.ItemDoPedidoRepository.Insert(item);

            return ret;

            //throw new System.NotImplementedException();
        }

        public List<Ingrediente> ListarIngredientes()
        {
            return IngredienteRepository.GetAll().ToList();
        }

        public List<Lanche> ListarLanches()
        {
            return LancheRepository.GetAll().ToList();
        }
    }
}