using CubleDaLeitura.ConsoleApp.Controladores;
using CubleDaLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp.Telas
{
    class TelaCaixa : TelaBase
    {
        private ControladorCaixa controladorCaixa;

        public TelaCaixa(ControladorCaixa controladorCaixa)
        {
            this.controladorCaixa = controladorCaixa;
        }

        public override string ObterTitulo()
        {
            return "Caixas";
        }

        public override void Registrar(int id)
        {
            Console.Clear();
            Console.Write("Digite a cor da caixa: ");
            string corCaixa = Console.ReadLine();

            Console.Write("Digite a etiqueta da caixa: ");
            string etiquetaCaixa = Console.ReadLine();

            controladorCaixa.RegistrarCaixa(id, corCaixa, etiquetaCaixa);
        }
        public override bool Visualizar()
        {
            Console.Clear();
            Caixa[] caixas = controladorCaixa.SelecionarTodasCaixas();
            if (caixas.Length == 0)
            {
                Console.WriteLine("Nenhuma caixa cadastrada...");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("    ---Caixas---");
                for (int i = 0; i < caixas.Length; i++)
                {

                    Console.WriteLine("\nID: " + caixas[i].id);
                    Console.WriteLine("Cor: " + caixas[i].corCaixa);
                    Console.WriteLine("Etiqueta: " + caixas[i].etiquetaCaixa);
                }
                Console.ReadLine();
                return false;
            }
        }

        public override void Excluir()
        {
            Console.Clear();
            bool vazio = Visualizar();
            if(vazio == false)
            {
                Console.Write("\nDigite o ID da caixa que deseja excluir: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());
                controladorCaixa.ExcluirCaixa(idSelecionado);
            }
        }
        public override void Editar()
        {
            Console.Clear();
            bool vazio = Visualizar();
            if (vazio == false)
            {
                Console.Write("\nDigite o ID da caixa que deseja editar: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());
                Registrar(idSelecionado);
            }
        }
    }
}
