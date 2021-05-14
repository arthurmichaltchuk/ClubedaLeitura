using CubleDaLeitura.ConsoleApp.Controladores;
using CubleDaLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp.Telas
{
    class TelaEmprestimo : TelaBase
    {
        private ControladorEmprestimo controladorEmprestimo;
        private TelaRevista telaRevista;
        private TelaAmiguinho telaAmiguinho;

        public TelaEmprestimo(TelaRevista telaR, TelaAmiguinho telaA)
        {
            telaRevista = telaR;
            telaAmiguinho = telaA;
        }

        public TelaEmprestimo(ControladorEmprestimo controladorEmprestimo)
        {
            this.controladorEmprestimo = controladorEmprestimo;
        }

        public void Devolver()
        {
            bool vazio = VisualizarEmAberto();
            if (vazio == false)
            {
                Console.WriteLine("Digite o ID do emprestimo que será devolvido: ");
                int idDevolucao = Convert.ToInt32(Console.ReadLine());
                controladorEmprestimo.Devolver(idDevolucao);
            }
        }

        internal void VisualizarHistorico()
        {
            Console.Clear();
            Emprestimo[] emprestimo = controladorEmprestimo.SelecionarTodasEmprestimos();
            if (emprestimo.Length == 0)
            {
                Console.WriteLine("Nenhuma emprestimo realizado...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Digite o mês dos emprestimos que deseja visualizar: (MM)");
                string mesEmprestimo = Console.ReadLine();

                Console.WriteLine("    ---Emprestimos-Todos---");
                for (int i = 0; i < emprestimo.Length; i++)
                {
                    if (emprestimo[i].dataEmprestimo.ToString("MM") == mesEmprestimo)
                    {
                        Console.WriteLine("\nID: " + emprestimo[i].id);
                        Console.WriteLine("Amigo que pegou emprestado: " + emprestimo[i].amigo.nome);
                        Console.WriteLine("Revista emprestada: " + emprestimo[i].revista.TipoDeColecao);
                        Console.WriteLine("Data do emprestimo: " + emprestimo[i].dataEmprestimo.ToString("dd/MM/yyyy"));
                        Console.WriteLine("Data de devolução: " + emprestimo[i].dataDevolucao.ToString("dd/MM/yyyy"));
                        if (emprestimo[i].aberto)
                            Console.WriteLine("EM ABERTO...");
                        else
                            Console.WriteLine("JÁ DEVOLVIDO");
                    }
                }
                Console.ReadLine();
            }
        }

        internal bool VisualizarEmAberto()
        {
            Console.Clear();
            Emprestimo[] emprestimo = controladorEmprestimo.SelecionarTodasEmprestimos();
            if (emprestimo.Length == 0)
            {
                Console.WriteLine("Nenhuma emprestimo realizado...");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("    ---Emprestimos-em-Aberto--");
                for (int i = 0; i < emprestimo.Length; i++)
                {
                    if (emprestimo[i].aberto == true)
                    {                
                        Console.WriteLine("\nID: " + emprestimo[i].id);
                        Console.WriteLine("Amigo que pegou emprestado: " + emprestimo[i].amigo.nome);
                        Console.WriteLine("Revista emprestada: " + emprestimo[i].revista.TipoDeColecao);
                        Console.WriteLine("Data do emprestimo: " + emprestimo[i].dataEmprestimo.ToString("dd/MM/yyyy"));
                        Console.WriteLine("Data de devolução: " + emprestimo[i].dataDevolucao.ToString("dd/MM/yyyy"));
                    }
                }
                Console.ReadLine();
                return false;
            }
        }

        internal void Emprestar(int id, TelaRevista telaRevista, TelaAmiguinho telaAmiguinho)
        {
            bool vazio = telaRevista.Visualizar();
            if (vazio == false)
            {
                Console.WriteLine("Digite o ID da revista que será emprestada: ");
                int idRevista = Convert.ToInt32(Console.ReadLine());

                bool vazio2 = telaAmiguinho.Visualizar();
                if (vazio2 == false)
                {
                    Console.WriteLine("Digite o ID do amigo que deseja pegar emprestado: ");
                    int idAmigo = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Digite o dia de devolução");
                    DateTime dataDevolucao = Convert.ToDateTime(Console.ReadLine());
                    DateTime dataEmprestimo = DateTime.Now;

                    controladorEmprestimo.Emprestimo(id, idRevista, idAmigo, dataDevolucao, dataEmprestimo);
                }
            }          
        }
    }
}
