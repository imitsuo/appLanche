using System;

namespace appLanche.Domain
{
    public class Promocao
    {
        public int Id {get; protected set;}
        public string Nome {get; protected set;}
        public TipoPromocao Tipo {get; protected set;}
        public Ingrediente IngredienteObrigatorio {get; protected set;}

        public Ingrediente IngredienteRemovido{get; protected set;}

        public decimal PercentualDesconto{get; protected set;}

        public int QuantidadeDeItens {get; protected set;}

        public Ingrediente IngredienteAdicional {get; protected set;}

        private Promocao()
        {}
        public Promocao(string nome, Ingrediente ingredienteObrigatorio, Ingrediente ingredienteRemovido, decimal percentualDesconto)
        {
            //this.Id = id;
            this.Nome = nome;
            this.IngredienteObrigatorio = ingredienteObrigatorio;
            this.IngredienteRemovido = ingredienteRemovido;
            this.PercentualDesconto = percentualDesconto;
            this.Tipo = TipoPromocao.Light;
        }

        public Promocao(string nome, Ingrediente ingredienteAdicional, int quantidade)
        {
            //this.Id = id;
            this.Nome = nome;
            this.IngredienteAdicional = ingredienteAdicional;
            this.QuantidadeDeItens = quantidade;
            this.Tipo = TipoPromocao.MuitoMais;
        }

    }      
    


    public enum TipoPromocao
    {        
        MuitoMais = 1,
        Light = 2
    }
}
