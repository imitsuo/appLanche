
using System;
using System.Collections.Generic;
using System.Threading;
using appLanche.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace appLanche.Infrastructure
{
    public class DbInitializer : IDbInitializer
    {
        private IRepository<Lanche> LancheRepository;
        private IRepository<ItemDoPedido> ItemDoPedidoRepository;
        private IRepository<Ingrediente> IngredienteRepository;
        private IRepository<Promocao> PromocaoRepository;
        private IServiceProvider ServiceProvider;

        public DbInitializer(IRepository<Lanche> lancheRepository,
                             IRepository<ItemDoPedido> itemDoPedidoRepository,
                             IRepository<Ingrediente> ingredienteRepository,
                             IRepository<Promocao> promocaoRepository,
                             IServiceProvider serviceProvider
                            )
        {
            this.LancheRepository = lancheRepository;
            this.ItemDoPedidoRepository = itemDoPedidoRepository;
            this.IngredienteRepository = ingredienteRepository;
            this.PromocaoRepository = promocaoRepository;
            this.ServiceProvider = serviceProvider;
        }

        public void Initialize()
        {
            //Console.WriteLine("Aperte qualquer tecla para iniciar");
            //Console.ReadLine();
            //Thread.Sleep(5000);

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

            /*var ingredientes = new List<Ingrediente>();
            ingredientes.Add(bacon);
            ingredientes.Add(hamburguerCarne);
            ingredientes.Add(queijo);

            var xbacon = new Lanche("X-Bacon", ingredientes);
            this.LancheRepository.Insert(xbacon);


            var ingre2 = new List<Ingrediente>();            
            ingre2.Add(hamburguerCarne);
            ingre2.Add(queijo);

            var xburguer = new Lanche("X-Burguer", ingre2);
            this.LancheRepository.Insert(xburguer);

            ingredientes = new List<Ingrediente>();            
            ingredientes.Add(hamburguerCarne);
            ingredientes.Add(queijo);
            ingredientes.Add(ovo);

            var xegg = new Lanche("X-Egg", ingredientes);
            this.LancheRepository.Insert(xegg);

            ingredientes = new List<Ingrediente>();            
            ingredientes.Add(hamburguerCarne);
            ingredientes.Add(queijo);
            ingredientes.Add(ovo);
            ingredientes.Add(bacon);

            var xeggbacon = new Lanche("X-Egg Bacon", ingredientes);
            this.LancheRepository.Insert(xeggbacon);*/


            using (var context = new LancheContext(
                ServiceProvider.GetRequiredService<DbContextOptions<LancheContext>>()))
            {
               var xbacon = new Lanche("X-Bacon", new List<Ingrediente>());

                context.Lanches.Add(xbacon);
                xbacon.AdicionarIngrediente(context.Ingredientes.Find(bacon.Id));
                xbacon.AdicionarIngrediente(context.Ingredientes.Find(hamburguerCarne.Id));
                xbacon.AdicionarIngrediente(context.Ingredientes.Find(queijo.Id));
                //context.SaveChanges();
                                
                var xburguer = new Lanche("X-Burguer", new List<Ingrediente>());    
                
                context.Lanches.Add(xburguer);
                xburguer.AdicionarIngrediente(context.Ingredientes.Find(hamburguerCarne.Id));
                xburguer.AdicionarIngrediente(context.Ingredientes.Find(queijo.Id));
                
                var xegg = new Lanche("X-Egg", new List<Ingrediente>());
                
                context.Lanches.Add(xegg);                
                xegg.AdicionarIngrediente(context.Ingredientes.Find(hamburguerCarne.Id));
                xegg.AdicionarIngrediente(context.Ingredientes.Find(queijo.Id));
                xegg.AdicionarIngrediente(context.Ingredientes.Find(ovo.Id));


                var xeggbacon = new Lanche("X-Egg Bacon", new List<Ingrediente>());
                context.Lanches.Add(xeggbacon); 

                xeggbacon.AdicionarIngrediente(context.Ingredientes.Find(hamburguerCarne.Id));
                xeggbacon.AdicionarIngrediente(context.Ingredientes.Find(queijo.Id));
                xeggbacon.AdicionarIngrediente(context.Ingredientes.Find(ovo.Id));
                xeggbacon.AdicionarIngrediente(context.Ingredientes.Find(bacon.Id));

                context.SaveChanges();


            }
        }
    }
}