using CubleDaLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp.Controladores
{
    class ControladorEmprestimo : ControladorBase
    {
        private ControladorRevista controladorRevista;
        private ControladorAmiguinho controladorAmiguinho;

        public ControladorEmprestimo(ControladorRevista controladorR, ControladorAmiguinho controladorA)
        {
            this.controladorAmiguinho = controladorA;
            this.controladorRevista = controladorR;
        }


        internal void Emprestimo(int id, int idRevista, int idAmigo, DateTime dataDevolucao, DateTime dataEmprestimo)
        {
            Emprestimo emprestimo;

            int posicao = ObterPosicaoParaEmprestimo(id);

            if (id == 0)
                emprestimo = new Emprestimo();
            else
                emprestimo = (Emprestimo)registros[posicao];

            emprestimo.dataDevolucao = dataDevolucao;
            emprestimo.dataEmprestimo = dataEmprestimo;
            emprestimo.aberto = true;
            emprestimo.revista = controladorRevista.SelecionarRevistaPorId(idRevista);
            emprestimo.amigo = controladorAmiguinho.SelecionarAmigoPorId(idAmigo);
            emprestimo.revista.emprestado = true;

            if (emprestimo.amigo.emprestou == false)
            {
                registros[posicao] = emprestimo;
                emprestimo.revista.emprestado = false;
                emprestimo.amigo.emprestou = true;
            }
            else
            {
                Console.WriteLine("Este amigo já pegou uma revista emprestada...");
                Console.ReadLine();
            }               
        }

        internal void Devolver(int idDevolucao)
        {
            Emprestimo emprestimo;

            int posicao = 0;

            posicao = ObterPosicaoParaEmprestimo(idDevolucao);
            emprestimo = (Emprestimo)registros[posicao];
            int idAmigo = emprestimo.amigo.id;


            emprestimo.aberto = false;

            emprestimo.amigo.emprestou = false;
        }

        private int ObterPosicaoParaEmprestimo(int id)
        {
            return ObterPosicaoParaRegistros(new Emprestimo(id), id);
        }
        internal Emprestimo[] SelecionarTodasEmprestimos()
        {
            return Array.ConvertAll(SelecionarTodosRegistros(), e => (Emprestimo)e);
        }
    }
}
