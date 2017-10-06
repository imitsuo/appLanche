
using System.Collections.Generic;
using appLanche.Domain;

namespace appLanche.Infrastructure
{
    public class DbInitializer : IDbInitializer
    {
        private IRepository<Lanche> LancheRepository;
        private IRepository<ItemDoPedido> ItemDoPedidoRepository;
        private IRepository<Ingrediente> IngredienteRepository;

        private IRepository<Promocao> PromocaoRepository;


        public DbInitializer(IRepository<Lanche> lancheRepository,
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

        public void Initialize()
        {

            Ingrediente alface = new Ingrediente(1, "Alface", new decimal(0.40));
            Ingrediente bacon = new Ingrediente(2, "Bacon", new decimal(2.00));
            Ingrediente hamburguerCarne = new Ingrediente(3, "Hambúrguer de carne", new decimal(3.00));
            Ingrediente ovo = new Ingrediente(4, "Ovo", new decimal(0.80));
            Ingrediente queijo = new Ingrediente(5, "Queijo", new decimal(1.50));
            Ingrediente pao = new Ingrediente(6, "Pao", new decimal(1.50));

            this.IngredienteRepository.Insert(alface);
            this.IngredienteRepository.Insert(bacon);
            this.IngredienteRepository.Insert(hamburguerCarne);
            this.IngredienteRepository.Insert(ovo);
            this.IngredienteRepository.Insert(queijo);
            this.IngredienteRepository.Insert(pao);

            this.PromocaoRepository.Insert(new Promocao("Light", alface, bacon, new decimal(0.1)));
            this.PromocaoRepository.Insert(new Promocao("Mais Carne",hamburguerCarne , 3));
            this.PromocaoRepository.Insert(new Promocao("Mais Queijo",queijo , 3));

            var ingredientes = new List<Ingrediente>();
            ingredientes.Add(bacon);
            ingredientes.Add(hamburguerCarne);
            ingredientes.Add(queijo);

            var lanche = new Lanche("X-Bacon", ingredientes);
            this.LancheRepository.Insert(lanche);
        }
    }
}