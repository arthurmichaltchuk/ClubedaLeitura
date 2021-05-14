using CubleDaLeitura.ConsoleApp.Controladores;
using CubleDaLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp.Telas
{
    class TelaRevista : TelaBase
    {
        private ControladorRevista controladorRevista;
        private TelaCaixa telaCaixa;

        public TelaRevista(ControladorRevista controladorRevista, TelaCaixa telac)
        {
            this.controladorRevista = controladorRevista;
            this.telaCaixa = telac;
        }

        public override string ObterTitulo()
        {
            return "Revistas";
        }

        public override void Registrar(int id)
        {
            bool vazio = telaCaixa.Visualizar();
            if (vazio==false)
            {
            Console.Write("Digite o ID da caixa onde esta a revista: ");
            int idCaixa = Convert.ToInt16(Console.ReadLine());     
            
            Console.Write("Digite o nome da revista: ");
            string TipoDeColecao = Console.ReadLine();

            Console.Write("Digite o número da edição: ");
            double dataFabricacao = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o ano da revista: ");
            int AnoDaRevista = Convert.ToInt32(Console.ReadLine());

            controladorRevista.RegistrarRevista(idCaixa, id, TipoDeColecao, dataFabricacao, AnoDaRevista);
            }
        }
        
        public override bool Visualizar()
        {
            Console.Clear();
            Revista[] revistas = controladorRevista.SelecionarTodasRevistas();
            if (revistas.Length == 0)
            {
                Console.WriteLine("Nenhuma revista cadastrada...");
                Console.ReadLine();
                return true;
            }
            else
            {             
                Console.WriteLine("    ---Revistas---");
                for (int i = 0; i < revistas.Length; i++)
                {
                    if (revistas[i].emprestado == false)
                    {
                        Console.WriteLine("\nID: " + revistas[i].id);
                        Console.WriteLine("Nome da revista: " + revistas[i].TipoDeColecao);
                        Console.WriteLine("Número da edição: " + revistas[i].NumeroDaEdicao);
                        Console.WriteLine("Ano da revista: " + revistas[i].AnoDaRevista);
                        Console.WriteLine("Caixa onde está: " + revistas[i].CaixaOndeEsta.corCaixa);
                    }
                    else
                    {
                        Console.WriteLine("A revista "+ revistas[i].TipoDeColecao+" está emprestada");
                    }
                }
                Console.ReadLine();
                return false;
            }
        }

        public override void Excluir()
        {
            Console.Clear();
            bool vazio = Visualizar();
            if (vazio == false)
            {
                Console.Write("\nDigite o ID da caixa que deseja excluir: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());
                controladorRevista.ExcluirRevista(idSelecionado);
            }
        }
        public override void Editar()
        {
            Console.Clear();
            bool vazio = Visualizar();
            if (vazio == false)
            {
                Console.Write("\nDigite o ID da revista que deseja editar: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());
                Registrar(idSelecionado);
            }
        }       
    }
}
