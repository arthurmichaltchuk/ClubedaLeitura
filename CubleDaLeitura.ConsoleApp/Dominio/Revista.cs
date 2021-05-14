using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp.Dominio
{
    class Revista
    {
        public int id;
        public string TipoDeColecao;
        public double NumeroDaEdicao;
        public int AnoDaRevista;
        public Caixa CaixaOndeEsta;
        public bool emprestado;
        
        public Revista()
        {
            id = GeradorId.GerarIdRevista();
        }
        public Revista(int id)
        {
            this.id = id;
        }
        public override bool Equals(object obj)
        {
            Revista r = (Revista)obj;

            if (r != null && r.id == this.id)
                return true;

            return false;
        }
    }
}
