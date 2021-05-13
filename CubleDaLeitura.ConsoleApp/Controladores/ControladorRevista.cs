using CubleDaLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp.Controladores
{
    class ControladorRevista : ControladorBase
    {
        private ControladorCaixa controladorCaixa;

        public ControladorRevista(ControladorCaixa controladorCaixa)
        {
            this.controladorCaixa = controladorCaixa;
        }

        internal void RegistrarRevista(int idCaixa, int id, string tipoDeColecao, double dataFabricacao, int anoDaRevista)
        {
            Revista revista;

            int posicao = ObterPosicaoParaRevista(id);

            if (id == 0)
                revista = new Revista();
            else
                revista = (Revista)registros[posicao];
         
            revista.TipoDeColecao = tipoDeColecao;
            revista.NumeroDaEdicao = dataFabricacao;
            revista.AnoDaRevista = anoDaRevista;
            revista.CaixaOndeEsta = controladorCaixa.SelecionarCaixaPorId(idCaixa);
            registros[posicao] = revista;
        }

        internal Revista[] SelecionarTodasRevistas()
        {
            return Array.ConvertAll(SelecionarTodosRegistros(), r => (Revista)r);
        }

        private int ObterPosicaoParaRevista(int id)
        {
            return ObterPosicaoParaRegistros(new Revista(id), id);
        }

        public void ExcluirRevista(int idSelecionado)
        {
            ExcluirRegistro(new Revista(idSelecionado));
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            return (Revista)SelecionarRegistroPorId(new Revista(id));
        }
    }
}
