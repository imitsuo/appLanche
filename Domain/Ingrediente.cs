using System;

namespace appLanche.Domain
{
    public class Ingrediente
    {
        public int Id {get; protected set;}

        public string Nome {get; protected set;}

        public decimal Valor {get; protected set;}

        private Ingrediente()
        {}
        
        public Ingrediente(int id, string nome, decimal valor)
        {
            this.Id = id;
            this.Nome = nome;
            this.Valor = valor;
        }

        public Ingrediente(string nome, decimal valor)
        {
         //   this.ID = id;
            this.Nome = nome;
            this.Valor = valor;
        }
    }
}
