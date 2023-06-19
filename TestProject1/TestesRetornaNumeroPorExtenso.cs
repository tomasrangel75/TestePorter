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
        public void Teste__Sucesso()
        {
            ulong numero = 12345;

            var resultado = conversor.RetornaNumeroPorExtenso(numero);

            Assert.Equal("doze mil e trezentos e quarenta e cinco", resultado);
        }

        [Fact]
        public void Teste_Sucesso_1_Dig()
        {
            ulong numero = 0;

            var resultado = conversor.RetornaNumeroPorExtenso(numero);

            Assert.Equal("zero", resultado);
        }

        [Fact]
        public void Teste_Sucesso_Dezena()
        {
            ulong numero = 22;

            var resultado = conversor.RetornaNumeroPorExtenso(numero);

            Assert.Equal("vinte e dois", resultado);
        }

        [Fact]
        public void Teste_Sucesso_Centena()
        {
            ulong numero = 222;

            var resultado = conversor.RetornaNumeroPorExtenso(numero);

            Assert.Equal("duzentos e vinte e dois", resultado);
        }

        [Fact]
        public void Teste_Sucesso_Milhar()
        {
            ulong numero = 1222;

            var resultado = conversor.RetornaNumeroPorExtenso(numero);

            Assert.Equal("mil e duzentos e vinte e dois", resultado);
        }

        [Fact]
        public void Teste_Sucesso_Milhao()
        {
            ulong numero = 1222000;

            var resultado = conversor.RetornaNumeroPorExtenso(numero);

            Assert.Equal("um milhão e duzentos e vinte e dois mil", resultado);
        }

        [Fact]
        public void Teste_Falha_Digito()
        {
            ulong numero = 1234500000;

            Assert.Throws<ArgumentOutOfRangeException> (() => conversor.RetornaNumeroPorExtenso(numero));
        }
    }
}