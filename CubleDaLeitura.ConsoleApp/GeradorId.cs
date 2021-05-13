namespace CubleDaLeitura.ConsoleApp.Dominio
{
    internal class GeradorId
    {
        private static int idCaixa = 0;
        private static int idRevista = 0;
        private static int idAmiguinho = 0;
        private static int idEmprestimo = 0;
        
        public static int GerarIdCaixa()
        {
            return ++idCaixa;
        }
        public static int GerarIdRevista()
        {
            return ++idRevista;
        }
        public static int GerarIdAmiguinho()
        {
            return ++idAmiguinho;
        }
        
        public static int GerarIdEmprestimo()
        {
            return ++idEmprestimo;
        }
    }
}