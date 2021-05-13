using CubleDaLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp.Controladores
{
    class ControladorCaixa : ControladorBase
    {
        internal void RegistrarCaixa(int id, string corCaixa, string etiquetaCaixa)
        {
            Caixa caixa;

            int posicao = ObterPosicaoParaCaixas(id);

            if (id == 0)
                caixa = new Caixa();
            else
                caixa = (Caixa)registros[posicao];

            caixa.corCaixa = corCaixa;
            caixa.etiquetaCaixa = etiquetaCaixa;

            registros[posicao] = caixa;
        }

        private int ObterPosicaoParaCaixas(int id)
        {
            return ObterPosicaoParaRegistros(new Caixa(id), id);
        }
        public Caixa SelecionarCaixaPorId(int id)
        {
            return (Caixa)SelecionarRegistroPorId(new Caixa(id));
        }

        public Caixa[] SelecionarTodasCaixas()
        {
            return Array.ConvertAll(SelecionarTodosRegistros(), c => (Caixa)c);
        }

        public void ExcluirCaixa(int idSelecionado)
        {
            ExcluirRegistro(new Caixa(idSelecionado));
        }
    }
}
