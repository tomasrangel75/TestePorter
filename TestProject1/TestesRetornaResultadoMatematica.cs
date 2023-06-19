using TestePorter.Classes;

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
        public void Teste_Expressao_Simples_Sucesso()
        {
            string expressaoMatematica = "1+1";

            var resultado = conversor.RetornaResultadoMatematica(expressaoMatematica);

            Assert.Equal("1+1 = 2", resultado);
        }
    }
}