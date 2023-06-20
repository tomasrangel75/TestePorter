using Microsoft.VisualBasic;
using System;
using TestePorter.Enums;
using TestePorter.Interfaces;
using System.Linq;
using TestePorter.Exceptions;
using System.Diagnostics.Metrics;
using System.Collections.Concurrent;

namespace TestePorter.Classes
{
    public class Conversor : IConversor
    {
        public Conversor()
        {


        }

        #region props

        public Operacao OperacaoEscolhida { get; set; }

        #endregion

        #region fields

        private static readonly List<string> list = new List<string>()
            {
                "1","2","3","4","5","6","7","8","9","0","+","-","/","*"
            };

        private static readonly List<string> Operadores = new List<string>()
            {
                "+","-","/","*"
            };

        #endregion

        #region public methods

        public static List<OperacaoTipo> RetornaOperacoes()
        {
            return new List<OperacaoTipo>
            {
                new OperacaoTipo()
                {
                     Descricao = "'Remover Objetos Repetidos': operação que recebe uma lista de objetos e retorna uma nnova lista apenas com os objetos únicos",
                     Operacao = Operacao.RemoveObjetosRepetidos,
                     Instrucao = "Digitar uma lista de objetos e pressionar ENTER"
                },
                new OperacaoTipo()
                {
                     Descricao = "'Retornar Número Por Extenso': operação que recebe um número inteiro e retorna representação por extenso desse número",
                     Operacao = Operacao.RetornaNumeroPorExtenso,
                     Instrucao = "Digitar um número inteiro e pressionar ENTER"
                },
                new OperacaoTipo()
                {
                     Descricao = "'Retornar Resultado Matemática': operação que recebe uma uma expressão nmatemática simples (sem parênteses) e retorna o resultado dessa expressão (exemplo: 2 + 3 * 5",
                     Operacao = Operacao.RetornaResultadoMatematica,
                     Instrucao = "Digitar expressão matemática e pressionar ENTER"
                },
                new OperacaoTipo()
                {
                     Descricao = "'Somar Números de um Array': operação que recebe um array de inteiros e retorna a soma desses números, o array pode ter até 1 milhão de números",
                     Operacao = Operacao.SomaNumerosArray,
                     Instrucao = "Digitar array de números inteiros e pressionar ENTER"
                }
            };
        }

        public IList<string> RetornaDescricoes()
        {
            var listaDeInstrucoes = new List<string>();

            foreach (var op in RetornaOperacoes())
            {
                listaDeInstrucoes.Add($"Digite {(int)op.Operacao} para {op.Descricao}\n");
            };

            return listaDeInstrucoes;
        }

        public string RetornaInstrucao()
        {
            var operacoes = RetornaOperacoes();
            var dadosOperacao = operacoes.FirstOrDefault(x => x.Operacao.Equals(OperacaoEscolhida));

            return $"{dadosOperacao.Instrucao}\n";
        }

        public IList<Dev>? RemoveObjetosRepetidos(IList<Dev> devs)
        {
            if (ListaDevsInvalida(devs)) throw new ArgumentException("Lista inválida.");

            try
            {
                return devs.Distinct(new DevComparer())?.ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string RetornaNumeroPorExtenso(ulong numero)
        {
            if (NumeroInvalido(numero)) throw new ArgumentOutOfRangeException("Número de dígitos inválido.");

            try
            {
                IConversorExtensao conversorExtensao = new ConversorExtensao();
                return conversorExtensao.ConverterNumero(numero);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string RetornaResultadoMatematica(string expressao)
        {
            if (ExpressaoInvalida(expressao)) throw new InvalidInputException("Input inválido.");
            if (DivisaoPorZero(expressao)) throw new DivideByZeroException("Input inválido, divisão por zero.");

            try
            {
                ICalculoMatematico calculoMatematico = new CalculoMatematico();
                return calculoMatematico.Executar(expressao);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public long SomaNumerosArray(int[] numeros)
        {
            if (ArrayNumerosInvalido(numeros)) throw new ArgumentException("Array vazio.");

            try
            {
                long sum = 0;
                var options = new ParallelOptions()
                { MaxDegreeOfParallelism = Environment.ProcessorCount };
                Parallel.ForEach(Partitioner.Create(0, numeros.Length), options, range =>
                {
                    long localSum = 0;
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        localSum += numeros[i];
                    }
                    Interlocked.Add(ref sum, localSum);
                });

                return sum;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region private methods

        private static bool ListaDevsInvalida(IList<Dev> devs)
        {
            return devs.Count == 0;
        }

        private static bool NumeroInvalido(ulong numero)
        {
            if (numero == 0) return false;

            var count = 0;

            while (numero > 0)
            {
                numero = numero / 10;
                count++;
            }

            return count < 1 || count > 9;
        }

        private static bool ExpressaoInvalida(string expressao)
        {
            var itemAnterior = "";
            var contador = 0;

            foreach (var item in expressao)
            {
                var strItem = item.ToString();
                if(Operadores.Contains(strItem) && Operadores.Contains(itemAnterior)) return true;
                ++contador;

                if ((contador == 1 || contador == expressao.Length ) && Operadores.Contains(strItem)) return true;
      
                if (!list.Contains(strItem)) return true;

                itemAnterior = strItem;
            }

            return false;
        }

        private static bool DivisaoPorZero(string expressao)
        {
            return expressao.Contains("/0");
        }

        private static bool ArrayNumerosInvalido(int[] numeros)
        {
            return numeros.Length < 1;
        }

        #endregion
    }
}
