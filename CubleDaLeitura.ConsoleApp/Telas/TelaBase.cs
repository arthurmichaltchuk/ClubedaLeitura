using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp.Telas
{
    class TelaBase
    {
        public virtual string ObterTitulo()
        {
            return "";
        }

        public virtual void Registrar(int id)
        {          
        }

        public virtual bool Visualizar()
        {
            return true;
        }

        public virtual void Editar()
        {
        }

        public virtual void Excluir()
        {       
        }

    }
}
