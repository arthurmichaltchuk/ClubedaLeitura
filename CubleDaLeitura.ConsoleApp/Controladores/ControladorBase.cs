using CubleDaLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp.Controladores
{
    class ControladorBase
    {
        public const int CAPACIDADE_REGISTROS = 100;
        public object[] registros = null;

        public ControladorBase()
        {
            registros = new object[CAPACIDADE_REGISTROS];
        }

        protected int ObterPosicaoParaRegistros(object obj, int idSelecionado)
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (idSelecionado == 0 && registros[i] == null)
                {
                    posicao = i;
                    break;
                }
                else if (registros[i] != null && registros[i].Equals(obj)) 
                {
                    posicao = i;
                    break;
                }
            }
            return posicao;
        }

        public object[] SelecionarTodosRegistros()
        {
            object[] objAux = new object[QtdRegistrosCasdastrados(registros)];

            int i = 0;

            foreach (object registro in registros)
            {
                if (registro != null)
                    objAux[i++] = registro;
            }
            return objAux;
        }

        private int QtdRegistrosCasdastrados(object[] registros)
        {
            int numeroCadastrados = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    numeroCadastrados++;
                }
            }

            return numeroCadastrados;
        }

        public void ExcluirRegistro(object obj)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj))
                {
                    registros[i] = null;
                    break;
                }
            }
        }
        protected object SelecionarRegistroPorId(object id)
        {
            object ObjAux = null;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i].Equals(id))
                {
                    ObjAux = registros[i];
                    break;
                }
            }
            return ObjAux;
        }
    }
}
