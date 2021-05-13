using CubleDaLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubleDaLeitura.ConsoleApp.Controladores
{
    class ControladorAmiguinho : ControladorBase
    {
        internal void RegistrarAmigo(int id, string nome, string nomeResponsavel, string telefone, string cep)
        {
            Amiguinho amiguinho;

            int posicao = ObterPosicaoParaAmiguinhos(id);

            if (id == 0)
                amiguinho = new Amiguinho();
            else
                amiguinho = (Amiguinho)registros[posicao];

            amiguinho.nome = nome;
            amiguinho.nomeResponsavel = nomeResponsavel;
            amiguinho.telefone = telefone;
            amiguinho.cep = cep;
            registros[posicao] = amiguinho;
        }

        public int ObterPosicaoParaAmiguinhos(int id)
        {
            return ObterPosicaoParaRegistros(new Amiguinho(id), id);
        }

        internal Amiguinho[] SelecionarTodosAmiguinhos()
        {
            return Array.ConvertAll(SelecionarTodosRegistros(), a => (Amiguinho)a);
        }

        internal void ExcluirAmigo(int idSelecionado)
        {
            ExcluirRegistro(new Amiguinho(idSelecionado));
        }
        public Amiguinho SelecionarAmigoPorId(int id)
        {
            return (Amiguinho)SelecionarRegistroPorId(new Amiguinho(id));
        }
    }
}