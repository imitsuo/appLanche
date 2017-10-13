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
        public ItemDoPedido CalcularValorDoPedido(ItemDoPedido item)
        {
            var promocoes = this.PromocaoRepository.GetAll().ToList();

            //item.ValorTotal = item.Valor;

            promocoes.ForEach(p =>
            {
                var calculaDesconto = new CalculaPromocaoFactory()
                            .Criar(p);

                var valor = calculaDesconto.CalculaDesconto(item);
                if(valor > 0)
                    item.AdicionarDesconto(valor, p);

            });

            //var ret = this.ItemDoPedidoRepository.Insert(item);

            return item;

            //throw new System.NotImplementedException();
        }

        public ItemDoPedido GerarPedido(ItemDoPedido item)
        {
            return this.ItemDoPedidoRepository.Insert(item);
        }
    

        public List<Ingrediente> ListarIngredientes()
        {
            return IngredienteRepository.GetAll().ToList();
        }

        public List<Lanche> ListarLanches()
        {
            return LancheRepository.GetItems(null,"IngredienteLanche","IngredienteLanche.Lanche", "IngredienteLanche.Ingrediente");            
        }

        public List<Lanche> ObterLanche(int id)
        {
            return LancheRepository.GetItems(l => l.Id == id,"IngredienteLanche","IngredienteLanche.Lanche", "IngredienteLanche.Ingrediente");            
        }
    }
}