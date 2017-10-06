using System;
using Xunit;
using appLanche.Domain;
using System.Collections.Generic;

namespace appLanche.Tests
{
    public class CalculaPromocaoMuitoMais_ValorTotal
    {
        Ingrediente alface = new Ingrediente(1 , "Alface", new decimal(0.40));
        Ingrediente bacon = new Ingrediente(2 , "Bacon", new decimal(2.00));
        Ingrediente hamburguerCarne = new Ingrediente(3 , "Hambúrguer de carne", new decimal(3.00));
        Ingrediente ovo = new Ingrediente(4 , "Ovo", new decimal(0.80));
        Ingrediente queijo = new Ingrediente(5 , "Queijo", new decimal(1.50));
        Ingrediente pao = new Ingrediente(5 , "Pao", new decimal(1.50));
        

        [Fact]
        public void PossuiDescontoAdicionouCarne3()
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

            var promocao = new Promocao("Mais Carne",hamburguerCarne , 3);

            var calculadoraPromocao = new CalculaPromocaoMuitoMais(promocao);
            var desconto = calculadoraPromocao.CalculaDesconto(itemPed);
            var valorTotal = itemPed.Valor - desconto;
            
            Assert.True(valorTotal.Equals(new decimal(14.90)), "Valor Deve Ser 14.90 o valor eh " + valorTotal);
        }

        [Fact]
        public void PossuiDescontoAdicionouCarne5()
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

            var promocao = new Promocao("Mais Carne",hamburguerCarne , 3);

            var calculadoraPromocao = new CalculaPromocaoMuitoMais(promocao);
            var desconto = calculadoraPromocao.CalculaDesconto(itemPed);
            var valorTotal = itemPed.Valor - desconto;
            
            Assert.True(valorTotal.Equals(new decimal(17.90)), "Valor Deve Ser 17.90 o valor eh " + valorTotal);
        }
        

        [Fact]
        public void NaoPossuiDescontoPromocaoLight()
        {
            var ingredientes = new List<Ingrediente>();
            ingredientes.Add(bacon);
            ingredientes.Add(hamburguerCarne);
            ingredientes.Add(queijo);

            var lanche = new Lanche("X-Bacon", ingredientes);

            var itemPed = new ItemDoPedido(lanche);            
            itemPed.AdicionarIngrediente(hamburguerCarne);            

             var promocao = new Promocao("Mais Carne",hamburguerCarne , 3);

            var calculadoraPromocao = new CalculaPromocaoMuitoMais(promocao);
            var desconto = calculadoraPromocao.CalculaDesconto(itemPed);
            var valorTotal = itemPed.Valor - desconto;
            
            Assert.True(valorTotal.Equals(new decimal(9.50)), "Valor Deve Ser 9.50 o valor eh " + valorTotal);
        }
    }
}
