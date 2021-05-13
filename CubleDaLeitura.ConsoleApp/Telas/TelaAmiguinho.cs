using CubleDaLeitura.ConsoleApp.Controladores;
using CubleDaLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp.Telas
{
    class TelaAmiguinho : TelaBase
    {
        private ControladorAmiguinho controladorAmiguinho;

        public TelaAmiguinho(ControladorAmiguinho controladorAmiguinho)
        {
            this.controladorAmiguinho = controladorAmiguinho;
        }

        public override string ObterTitulo()
        {
            return "Amigos";
        }
        public override void Registrar(int id)
        {
            Console.Clear();
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite telefone do responsável: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o CEP do amigo: ");
            string cep = Console.ReadLine();

            controladorAmiguinho.RegistrarAmigo(id, nome, nomeResponsavel, telefone, cep);
            
        }
        
        public override bool Visualizar()
        {
            Console.Clear();
            Amiguinho[] amiguinho = controladorAmiguinho.SelecionarTodosAmiguinhos();
            if (amiguinho.Length == 0)
            {
                Console.WriteLine("Nenhuma amigo cadastrado...");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("    ---Amigos---");
                for (int i = 0; i < amiguinho.Length; i++)
                {
                    Console.WriteLine("\nID: " + amiguinho[i].id);
                    Console.WriteLine("Nome do amigo: " + amiguinho[i].nome);
                    Console.WriteLine("Nome do responsável: " + amiguinho[i].nomeResponsavel);
                    Console.WriteLine("Telefone do responsável: " + amiguinho[i].telefone);
                    Console.WriteLine("CEP do amigo: " + amiguinho[i].cep);
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
                Console.Write("\nDigite o ID do amigo que deseja excluir: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());
                controladorAmiguinho.ExcluirAmigo(idSelecionado);
            }
        }
        public override void Editar()
        {
            Console.Clear();
            bool vazio = Visualizar();
            if (vazio == false)
            {
                Console.Write("\nDigite o ID do amigo que deseja editar: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());
                Registrar(idSelecionado);
            }
        }
    }
}
