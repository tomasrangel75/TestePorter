using TestePorter.Classes;

namespace TestProject
{
    public class TestesRemoveObjetosRepetidos
    {
        private readonly Conversor conversor;

        public TestesRemoveObjetosRepetidos()
        {
            conversor = new Conversor();
        }

        [Fact]
        public void Teste_FiltraLista_Sucesso()
        {
            List<Colaborador> listaDeColaboradores = RetornaColaboradores();

            listaDeColaboradores.RemoveAt(6);
            listaDeColaboradores.RemoveAt(5);
            listaDeColaboradores.RemoveAt(4);

            var resultado = conversor.RemoveObjetosRepetidos(listaDeColaboradores).ToList();

            Assert.Equal<List<Colaborador>>(listaDeColaboradores, resultado);
        }


        [Fact]
        public void Teste_ListaVazia_Falha()
        {
            var listaDeColaboradores = new List<Colaborador>();

            Assert.Throws<ArgumentException>(() => conversor.RemoveObjetosRepetidos(listaDeColaboradores));
        }


        [Fact]
        public void Teste_ListaNula_Falha()
        {
            var listaDeColaboradores = new List<Colaborador>();
            listaDeColaboradores = null;

            Assert.Throws<NullReferenceException>(() => conversor.RemoveObjetosRepetidos(listaDeColaboradores));
        }


        [Fact]
        public void Teste_Propriedade_Nula_Hash_Falha()
        {
            List<Colaborador> listaDeColaboradores = RetornaColaboradorPropriedadeNula();

            Assert.Throws<NullReferenceException>(() => conversor.RemoveObjetosRepetidos(listaDeColaboradores));
        }

        #region private methods

        private static List<Colaborador> RetornaColaboradores()
        {
            return new List<Colaborador>()
            {
                new Colaborador()
                {
                    Nome = "José da Silva",
                    Cargo = "Digitador"
                },
                new Colaborador()
                {
                    Nome = "Everton da Silva",
                    Cargo = "Digitador"
                },
                new Colaborador()
                {
                    Nome = "André Gouveia",
                    Cargo = "Digitador"
                },
                new Colaborador()
                {
                    Nome = "Armando Alvarez",
                    Cargo = "Digitador"
                },
                new Colaborador()
                {
                    Nome = "José da Silva",
                    Cargo = "Digitador"
                },
                new Colaborador()
                {
                    Nome = "José da Silva",
                    Cargo = "Digitador"
                },
                new Colaborador()
                {
                     Nome = "Armando Alvarez",
                    Cargo = "Digitador"
                }
            };
        }

        private static List<Colaborador> RetornaColaboradorPropriedadeNula()
        {
            return new List<Colaborador>()
            {
                new Colaborador()
                {
                    Nome = "",
                    Cargo = null
                }
            };
        }

        #endregion
    }
}