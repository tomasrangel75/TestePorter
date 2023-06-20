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
            List<Dev> listaDeColaboradores = RetornaColaboradores();

            listaDeColaboradores.RemoveAt(6);
            listaDeColaboradores.RemoveAt(5);
            listaDeColaboradores.RemoveAt(4);

            var resultado = conversor.RemoveObjetosRepetidos(listaDeColaboradores).ToList();

            Assert.Equal<List<Dev>>(listaDeColaboradores, resultado);
        }


        [Fact]
        public void Teste_ListaVazia_Falha()
        {
            var listaDeColaboradores = new List<Dev>();

            Assert.Throws<ArgumentException>(() => conversor.RemoveObjetosRepetidos(listaDeColaboradores));
        }


        [Fact]
        public void Teste_ListaNula_Falha()
        {
            var listaDeColaboradores = new List<Dev>();
            listaDeColaboradores = null;

            Assert.Throws<NullReferenceException>(() => conversor.RemoveObjetosRepetidos(listaDeColaboradores));
        }


        [Fact]
        public void Teste_Propriedade_Nula_Hash_Falha()
        {
            List<Dev> listaDeColaboradores = RetornaColaboradorPropriedadeNula();

            Assert.Throws<NullReferenceException>(() => conversor.RemoveObjetosRepetidos(listaDeColaboradores));
        }

        #region private methods

        private static List<Dev> RetornaColaboradores()
        {
            return new List<Dev>()
            {
                new Dev()
                {
                    Nome = "José da Silva",
                    Cargo = "Digitador"
                },
                new Dev()
                {
                    Nome = "Everton da Silva",
                    Cargo = "Digitador"
                },
                new Dev()
                {
                    Nome = "André Gouveia",
                    Cargo = "Digitador"
                },
                new Dev()
                {
                    Nome = "Armando Alvarez",
                    Cargo = "Digitador"
                },
                new Dev()
                {
                    Nome = "José da Silva",
                    Cargo = "Digitador"
                },
                new Dev()
                {
                    Nome = "José da Silva",
                    Cargo = "Digitador"
                },
                new Dev()
                {
                     Nome = "Armando Alvarez",
                    Cargo = "Digitador"
                }
            };
        }

        private static List<Dev> RetornaColaboradorPropriedadeNula()
        {
            return new List<Dev>()
            {
                new Dev()
                {
                    Nome = "",
                    Cargo = null
                }
            };
        }

        #endregion
    }
}