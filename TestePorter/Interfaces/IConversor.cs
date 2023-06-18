using TestePorter.Enums;

namespace TestePorter.Interfaces
{
    public interface IConversor
    {
        IList<string> RetornaDescricoes();

        string RetornaInstrucao();

        //Task<string> RetornaNumeroPorExtenso(int numero);

        //Task<int> SomaNumerosArray(int[] numeros);

        //Task<int> RetornaResultadoMatematica(string expressao);

        //Task<IList<object>> RemoveObjetosRepetidos(IList<object> objetos);

        Task<string> Executar(int numero);

        Task<int> Executar(int[] numeros);

        Task<int> Executar(string expressao);

        Task<IList<object>> Executar(IList<object> objetos);

    }
}
