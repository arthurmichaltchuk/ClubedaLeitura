using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp.Dominio
{
    class Emprestimo
    {
        public int id;
        public Amiguinho amigo;
        public Revista revista;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public bool aberto = true;

        public Emprestimo()
        {
            id = GeradorId.GerarIdEmprestimo();
        }
        public Emprestimo(int id)
        {
            this.id = id;
        }
        public override bool Equals(object obj)
        {
            Emprestimo e = (Emprestimo)obj;

            if (e != null && e.id == this.id)
                return true;

            return false;
        }
    }
}
