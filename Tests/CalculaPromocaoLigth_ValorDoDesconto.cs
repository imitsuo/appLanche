using System;
using Xunit;
using appLanche.Domain;
using System.Collections.Generic;

namespace appLanche.Tests
{
    public class CalculaPromocaoLigth_ValorDoDesconto
    {
        Ingrediente alface = new Ingrediente(1 , "Alface", new decimal(0.40));
        Ingrediente bacon = new Ingrediente(2 , "Bacon", new decimal(2.00));
        Ingrediente hamburguerCarne = new Ingrediente(3 , "Hambúrguer de carne", new decimal(3.00));
        Ingrediente ovo = new Ingrediente(4 , "Ovo", new decimal(0.80));
        Ingrediente queijo = new Ingrediente(5 , "Queijo", new decimal(1.50));
        Ingrediente pao = new Ingrediente(5 , "Pao", new decimal(1.50));
        

        [Fact]
        public void PossuiDescontoAdicionouAlfaceRemoveuBacon()
        {           

            var ingredientes = new List<Ingrediente>();
            ingredientes.Add(bacon);
            ingredientes.Add(hamburguerCarne);
            ingredientes.Add(queijo);

            var lanche = new Lanche("X-Bacon", ingredientes);

            var itemPed = new ItemDoPedido(lanche);
            itemPed.AdicionarIngrediente(alface);
            itemPed.RemoverIngrediente(bacon);

            var promocao = new Promocao("Light", alface, bacon, new decimal(0.1));

            var calculadoraPromocao = new CalculaPromocaoLigth(promocao);
            var desconto = calculadoraPromocao.CalculaDesconto(itemPed);
            var valorTotal = itemPed.Valor - desconto;

            Assert.True(3 == lanche.Ingredientes.Count, "Deve Conter 3 Ingredientes");            
            Assert.True(new decimal(0.1).Equals(desconto / itemPed.Valor), "Valor Deve Ser 0.1 o valor eh " + desconto);            
        }

        [Fact]
        public void PossuiDescontoAdicionouAlface()
        {            
            var ingredientes = new List<Ingrediente>();            
            ingredientes.Add(hamburguerCarne);
            ingredientes.Add(queijo);

            var lanche = new Lanche("X-Burguer", ingredientes);

            var itemPed = new ItemDoPedido(lanche);
            itemPed.AdicionarIngrediente(alface);

            var promocao = new Promocao("Light", alface, bacon, new decimal(0.1));

            var calculadoraPromocao = new CalculaPromocaoLigth(promocao);
            var desconto = calculadoraPromocao.CalculaDesconto(itemPed);                      
            
            Assert.True(new decimal(0.1).Equals(desconto / itemPed.Valor), "Valor Deve Ser 0.1 o valor eh " + desconto);
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
            itemPed.AdicionarIngrediente(alface);            

            var promocao = new Promocao("Light", alface, bacon, new decimal(0.1));

            var calculadoraPromocao = new CalculaPromocaoLigth(promocao);
            var desconto = calculadoraPromocao.CalculaDesconto(itemPed);
                        
            Assert.True(new decimal(0).Equals(desconto), "Valor Deve Ser 0 o valor eh " + desconto);            
        }
    }
}
