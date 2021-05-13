using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp.Dominio
{
    class Amiguinho
    {
        public int id;
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string cep;
        public bool emprestou = false;
        public Amiguinho()
        {
            id = GeradorId.GerarIdAmiguinho();
        }
        public Amiguinho(int id)
        {
            this.id = id;
        }
        public override bool Equals(object obj)
        {
            Amiguinho a = (Amiguinho)obj;

            if (a != null && a.id == this.id)
                return true;

            return false;
        }
    }
}
