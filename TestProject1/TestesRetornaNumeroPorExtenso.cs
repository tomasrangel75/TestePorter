using TestePorter.Classes;

namespace TestProject
{
    public class TestesRetornaNumeroPorExtenso
    {
        private readonly Conversor conversor;

        public TestesRetornaNumeroPorExtenso()
        {
            conversor = new Conversor();
        }

        [Fact]
        public void Teste__SimplesSucesso()
        {
            ulong numero = 12345;

            var resultado = conversor.RetornaNumeroPorExtenso(numero);

            Assert.Equal("doze mil e trezentos e quarenta e cinco", resultado);
        }
    }
}