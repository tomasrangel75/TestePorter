using Microsoft.VisualBasic;
using System;
using TestePorter.Enums;
using TestePorter.Interfaces;
using System.Linq;
using TestePorter.Exceptions;

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
                listaDeInstrucoes.Add($"Digite {((int)op.Operacao)} para {op.Descricao}\n");
            };

            return listaDeInstrucoes;
        }

        public string RetornaInstrucao()
        {
            var operacoes = RetornaOperacoes();
            var dadosOperacao = operacoes.FirstOrDefault(x => x.Operacao.Equals(OperacaoEscolhida));

            return $"{dadosOperacao.Instrucao}\n";
        }
  
        public IList<Colaborador>? RemoveObjetosRepetidos(IList<Colaborador> colaboradores)
        {
            if(ValidaListaColaboradores(colaboradores)) throw new ArgumentException("Lista inválida.");

            try
            {
                return colaboradores.Distinct(new ColaboradorComparer())?.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public string RetornaNumeroPorExtenso(ulong numero)
        {
            if (ValidaNumero(numero)) throw new ArgumentOutOfRangeException("Número de dígitos inválido.");

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
            if(ValidaExpressaoParenteses(expressao)) throw new InvalidInputException("Input inválido.");
            if (ValidaDivisaoPorZero(expressao)) throw new DivideByZeroException("Input inválido, divisão por zero.");

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

        public int SomaNumerosArray(int[] numeros)
        {
            if (ValidaArrayNumeros(numeros)) throw new ArgumentException("Array vazio.");

            try
            {
                var sum = numeros.AsParallel().Sum();

                return sum;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region private methods

        private static bool ValidaListaColaboradores(IList<Colaborador> colaboradores)
        {
            return colaboradores.Count == 0;
        }

        private static bool ValidaNumero(ulong numero)
        {
            if(numero == 0) return false;

            var count = 0;

            while (numero > 0)
            {
                numero = numero / 10;
                count++;
            }

            return count < 1 || count > 9;
        }

        private static bool ValidaExpressaoParenteses(string expressao)
        {
            return expressao.Contains('(') || expressao.Contains(')');
        }

        private static bool ValidaDivisaoPorZero(string expressao)
        {
            return expressao.Contains("/0");
        }

        private static bool ValidaArrayNumeros(int[] numeros)
        {
            return numeros.Length < 1;
        }

        #endregion
    }
}
