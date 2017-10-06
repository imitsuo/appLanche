using System;
using Xunit;
using appLanche.Domain;
using System.Collections.Generic;

namespace appLanche.Tests
{
    public class LancheService_ValorLanche
    {
        [Fact]
        public void DeveConterOsIngredientes()
        {
            var alface = new Ingrediente(1 , "Alface", new decimal(0.40));
            var bacon = new Ingrediente(2 , "Bacon", new decimal(2.00));
            var hamburguerCarne = new Ingrediente(3 , "Hambúrguer de carne", new decimal(3.00));
            var ovo = new Ingrediente(4 , "Ovo", new decimal(0.80));
            var queijo = new Ingrediente(5 , "Queijo", new decimal(1.50));
            var pao = new Ingrediente(5 , "Pao", new decimal(1.50));

            var ingredientes = new List<Ingrediente>();
            ingredientes.Add(bacon);
            ingredientes.Add(hamburguerCarne);
            ingredientes.Add(queijo);

            var lanche = new Lanche( "X-Bacon", ingredientes);

            Assert.True(3 == lanche.Ingredientes.Count, "Deve Conter 3 Ingredientes");
            Assert.True(lanche.Valor.Equals(new decimal(6.50)), "Valor Deve Ser 6.50 o valor eh " + lanche.Valor);            
        }
    }
}
