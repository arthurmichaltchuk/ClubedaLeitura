using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp.Dominio
{
    public class Caixa
    {
        public string corCaixa;
        public string etiquetaCaixa;
        public int id;
        public string[] revistasNaCaixa;

        public Caixa()
        {
            id = GeradorId.GerarIdCaixa();
        }
        public Caixa(int id)
        {
            this.id = id;
        }
        public override bool Equals(object obj)
        {
            Caixa c = (Caixa)obj;

            if (c != null && c.id == this.id)
                return true;

            return false;
        }
    }
}
