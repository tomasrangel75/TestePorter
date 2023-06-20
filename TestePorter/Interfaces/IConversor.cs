﻿using TestePorter.Classes;

namespace TestePorter.Interfaces
{
    public interface IConversor
    {
        IList<string> RetornaDescricoes();

        string RetornaInstrucao();

        string RetornaNumeroPorExtenso(ulong numero);

        int SomaNumerosArray(int[] numeros);

        string RetornaResultadoMatematica(string expressao);

        IList<Dev>? RemoveObjetosRepetidos(IList<Dev> devs);

    }
}
