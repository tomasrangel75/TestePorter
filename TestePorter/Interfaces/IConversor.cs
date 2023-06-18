namespace TestePorter.Interfaces
{
    public interface IConversor
    {
        IList<string> RetornaDescricoes();

        string RetornaInstrucao();

        string RetornaNumeroPorExtenso(ulong numero);

        int SomaNumerosArray(int[] numeros);

        int RetornaResultadoMatematica(string expressao);

        IList<object> RemoveObjetosRepetidos(IList<object> objetos);

    }
}
