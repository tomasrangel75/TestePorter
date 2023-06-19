using TestePorter.Classes;

namespace TestProject
{
    public class SomaNumerosArray
    {
        private readonly Conversor conversor;

        public SomaNumerosArray()
        {
            conversor = new Conversor();
        }

        [Fact]
        public void Teste_Sucesso()
        {
            int[] numeros = new int[] { 99, 98, 92, 97, 95 };

            var resultado = conversor.SomaNumerosArray(numeros);

            Assert.Equal(481, resultado);
        }

        [Fact]
        public void Teste_Falha_ArrayVazio()
        {
            int[] numeros = new int[] { };

            Assert.Throws<ArgumentException>(() => conversor.SomaNumerosArray(numeros));
        }

        [Fact]
        public void Teste_Falha_ArrayNula()
        {
            int[] numeros = new int[] { };
            numeros = null;

            Assert.Throws<NullReferenceException>(() => conversor.SomaNumerosArray(numeros));
        }
    }
}
