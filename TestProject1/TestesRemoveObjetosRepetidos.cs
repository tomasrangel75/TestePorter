using System.Xml.Linq;
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
        public void Teste_Sucesso()
        {
            var listaDeColaboradores = new List<Colaborador>()
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

            listaDeColaboradores.RemoveAt(6);
            listaDeColaboradores.RemoveAt(5);
            listaDeColaboradores.RemoveAt(4);

            var resultado = conversor.RemoveObjetosRepetidos(listaDeColaboradores).ToList();

            Assert.Equal<List<Colaborador>>(listaDeColaboradores, resultado);
        }
    }
}