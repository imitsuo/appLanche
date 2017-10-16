using System;
using Xunit;
using appLanche.Domain;
using System.Collections.Generic;
using appLanche.Infrastructure;
using Moq;
using appLanche.Services;
using System.Linq;

namespace appLanche.Tests
{
    public class PedidoService_CalculaPedido
    {
        Ingrediente alface = new Ingrediente(1 , "Alface", new decimal(0.40));
        Ingrediente bacon = new Ingrediente(2 , "Bacon", new decimal(2.00));
        Ingrediente hamburguerCarne = new Ingrediente(3 , "Hambúrguer de carne", new decimal(3.00));
        Ingrediente ovo = new Ingrediente(4 , "Ovo", new decimal(0.80));
        Ingrediente queijo = new Ingrediente(5 , "Queijo", new decimal(1.50));
        Ingrediente pao = new Ingrediente(5 , "Pao", new decimal(1.50));    
       

    
        [Fact]
        public void PromocaoLightAdicionouAlfaceRemoveuBacon()
        {           

            var ingredientes = new List<Ingrediente>();
            ingredientes.Add(bacon);
            ingredientes.Add(hamburguerCarne);
            ingredientes.Add(queijo);

            var lanche = new Lanche("X-Bacon", ingredientes);

            var itemPed = new ItemDoPedido(lanche);
            itemPed.AdicionarIngrediente(alface);
            itemPed.RemoverIngrediente(bacon);

            var mockLancheRepositoy = new Mock<IRepository<Lanche>>();
            var mockItemDoPedidoRepositoy = new Mock<IRepository<ItemDoPedido>>();
            var mockIngredienteRepositoy = new Mock<IRepository<Ingrediente>>();
            var mockPromoRepositoy = new Mock<IRepository<Promocao>>();

            mockPromoRepositoy.Setup(x => x.GetAll()).Returns(
                new List<Promocao>
                {
                    new Promocao("Light", alface, bacon, new decimal(0.1)),
                    new Promocao("Mais Queijo",queijo , 3),
                    new Promocao("Mais Carne",hamburguerCarne , 3)
                }
            );


            var service = new PedidoService(mockLancheRepositoy.Object, 
                                            mockItemDoPedidoRepositoy.Object, 
                                            mockIngredienteRepositoy.Object, 
                                            mockPromoRepositoy.Object);

            
            
            var ret = service.CalcularValorDoPedido(itemPed);
            

            Assert.True(ret.Descontos.Count > 0);
            Assert.True(3 == lanche.Ingredientes.Count, "Deve Conter 3 Ingredientes");            
            Assert.True(new decimal(0.1).Equals(itemPed.Descontos.Sum(x => x.Valor) / itemPed.Valor), "Valor Deve Ser 0.1 o valor eh " + itemPed.Descontos.Sum(x => x.Valor) / itemPed.Valor);            
        }

         [Fact]
        public void PromocaoMaisAdicionouCarne5()
        {           

            var ingredientes = new List<Ingrediente>();
            ingredientes.Add(bacon);
            ingredientes.Add(hamburguerCarne);
            ingredientes.Add(queijo);

            var lanche = new Lanche("X-Bacon", ingredientes);

            var itemPed = new ItemDoPedido(lanche);
            itemPed.AdicionarIngrediente(alface);
            itemPed.AdicionarIngrediente(bacon);
            itemPed.AdicionarIngrediente(hamburguerCarne);
            itemPed.AdicionarIngrediente(hamburguerCarne);
            itemPed.AdicionarIngrediente(hamburguerCarne);
            itemPed.AdicionarIngrediente(hamburguerCarne);
            itemPed.AdicionarIngrediente(hamburguerCarne);

            var mockLancheRepositoy = new Mock<IRepository<Lanche>>();
            var mockItemDoPedidoRepositoy = new Mock<IRepository<ItemDoPedido>>();
            var mockIngredienteRepositoy = new Mock<IRepository<Ingrediente>>();
            var mockPromoRepositoy = new Mock<IRepository<Promocao>>();

            mockPromoRepositoy.Setup(x => x.GetAll()).Returns(
                new List<Promocao>
                {
                    new Promocao("Light", alface, bacon, new decimal(0.1)),
                    new Promocao("Mais Queijo",queijo , 3),
                    new Promocao("Mais Carne",hamburguerCarne , 3)
                }
            );


            var service = new PedidoService(mockLancheRepositoy.Object, 
                                            mockItemDoPedidoRepositoy.Object, 
                                            mockIngredienteRepositoy.Object, 
                                            mockPromoRepositoy.Object);

            
            
            var ret = service.CalcularValorDoPedido(itemPed);

             
            Assert.True(ret.ValorTotal.Equals(new decimal(17.90)), "Valor Deve Ser 17.90 o valor eh " + ret.ValorTotal);
        }
    }
}
