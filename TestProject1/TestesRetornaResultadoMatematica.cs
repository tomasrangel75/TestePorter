using TestePorter.Classes;
using TestePorter.Exceptions;

namespace TestProject
{
    public class TestesRetornaResultadoMatematica
    {
        private readonly Conversor conversor;

        public TestesRetornaResultadoMatematica()
        {
            conversor = new Conversor();
        }

        [Fact]
        public void Teste_Adicao_Sucesso()
        {
            string expressaoMatematica = "1+1";

            var resultado = conversor.RetornaResultadoMatematica(expressaoMatematica);

            Assert.Equal("1+1 = 2", resultado);
        }

        [Fact]
        public void Teste_Subtracao_Sucesso()
        {
            string expressaoMatematica = "1-1";

            var resultado = conversor.RetornaResultadoMatematica(expressaoMatematica);

            Assert.Equal("1-1 = 0", resultado);
        }

        [Fact]
        public void Teste_Multiplicacao_Sucesso()
        {
            string expressaoMatematica = "2*5";

            var resultado = conversor.RetornaResultadoMatematica(expressaoMatematica);

            Assert.Equal("2*5 = 10", resultado);
        }

        [Fact]
        public void Teste_Divisao_Sucesso()
        {
            string expressaoMatematica = "10/2";

            var resultado = conversor.RetornaResultadoMatematica(expressaoMatematica);

            Assert.Equal("10/2 = 5", resultado);
        }

        [Fact]
        public void Teste_ExpressaoComParenthesis_Falha()
        {
            string expressaoMatematica = "(2*2)+1";
     
            Assert.Throws<InvalidInputException>(() => conversor.RetornaResultadoMatematica(expressaoMatematica));
        }

        [Fact]
        public void Teste_DivisaoPorZero_Falha()
        {
            string expressaoMatematica = "1+2+2/0";

            Assert.Throws<DivideByZeroException>(() => conversor.RetornaResultadoMatematica(expressaoMatematica));
        }
    }
}