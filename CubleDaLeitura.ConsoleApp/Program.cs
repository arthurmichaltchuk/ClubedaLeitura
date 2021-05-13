using CubleDaLeitura.ConsoleApp.Controladores;
using CubleDaLeitura.ConsoleApp.Telas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ControladorCaixa controladorCaixa = new ControladorCaixa();
            ControladorRevista controladorRevista = new ControladorRevista(controladorCaixa);
            ControladorAmiguinho controladorAmiguinho = new ControladorAmiguinho();
            ControladorEmprestimo controladorEmprestimo = new ControladorEmprestimo(controladorRevista, controladorAmiguinho);
            TelaCaixa telacaixa = new TelaCaixa(controladorCaixa);
            TelaAmiguinho telaAmiguinho = new TelaAmiguinho(controladorAmiguinho);
            TelaRevista telaRevista = new TelaRevista(controladorRevista, telacaixa);
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(controladorEmprestimo);
            TelaBase telaMae = new TelaBase();

            while (true)
            {
                Console.Clear();
                string opcao = obterOpcao();
                
                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    break;
                if (opcao == "1")
                    telaMae = new TelaCaixa(controladorCaixa);
                else if (opcao == "2")
                    telaMae = new TelaAmiguinho(controladorAmiguinho);
                else if (opcao == "3")
                    telaMae = new TelaRevista(controladorRevista, telacaixa);
                else if (opcao == "4")
                {
                    telaMae = new TelaEmprestimo(controladorEmprestimo);
                    MenuOpcaoEmprestimo(telaEmprestimo, telaRevista, telaAmiguinho);
                    continue;
                }
                Console.Clear();
                while (true)
                {
                    string titulo = telaMae.ObterTitulo();
                    string opcaoCadastro = ObterControle(titulo);

                    if (opcaoCadastro == "1")
                        telaMae.Registrar(0);

                    else if (opcaoCadastro == "2")
                        telaMae.Visualizar();

                    else if (opcaoCadastro == "3")
                        telaMae.Editar();

                    else if (opcaoCadastro == "4")
                        telaMae.Excluir();

                    else if (opcaoCadastro == "5")
                        break;
                    Console.Clear();
                }
            }
        }

        private static string obterOpcao()
        {
            Console.WriteLine("    ---Menu Principal---");
            Console.WriteLine(" 1. Gerenciar Caixas...");
            Console.WriteLine(" 2. Gerenciar Amigos...");
            Console.WriteLine(" 3. Gerenciar Revistas...");
            Console.WriteLine(" 4. Fazer Emprestimo...");
            Console.WriteLine(" S. Sair...");

            string opcao = Console.ReadLine();
            return opcao;
        }
        public static string ObterControle(string titulo)
        {
            Console.WriteLine("    ---"+titulo+"---");
            Console.WriteLine(" 1. Cadastrar " + titulo + "...");
            Console.WriteLine(" 2. Visualizar " + titulo + "...");
            Console.WriteLine(" 3. Editar " + titulo + "...");
            Console.WriteLine(" 4. Excluir " + titulo + "...");
            Console.WriteLine(" 5. Voltar...");

            string opcaoCadastro = Console.ReadLine();
            return opcaoCadastro;
        }
        private static void MenuOpcaoEmprestimo(TelaEmprestimo telaEmprestimo, TelaRevista telaRevista, TelaAmiguinho telaAmiguinho)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("    ---Emprestimos---");
                Console.WriteLine(" 1. Fazer Emprestimo...");
                Console.WriteLine(" 2. Visualizar emprestimos em aberto...");
                Console.WriteLine(" 3. Visualizar todos os emprestimos por mês...");
                Console.WriteLine(" 4. Devolver Revista...");
                Console.WriteLine(" 5. Voltar...");

                string opcao = Console.ReadLine();

                if (opcao == "1")
                    telaEmprestimo.Emprestar(0 ,telaRevista, telaAmiguinho);

                else if (opcao == "2")
                    telaEmprestimo.VisualizarEmAberto();

                else if (opcao == "3")
                    telaEmprestimo.VisualizarHistorico();

                else if (opcao == "4")
                    telaEmprestimo.Devolver();

                else if (opcao == "5")
                    break;
            }
        }
    }
}
