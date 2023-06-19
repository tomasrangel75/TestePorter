using Microsoft.VisualBasic;
using System;
using TestePorter.Enums;
using TestePorter.Interfaces;
using System.Linq;

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
            ValidacaoListaColaboradores(colaboradores);
            return colaboradores.Distinct(new ColaboradorComparer())?.ToList();
        }

        public string RetornaNumeroPorExtenso(ulong numero)
        {
            ValidacaoNumero(numero);
            IConversorExtensao conversorExtensao = new ConversorExtensao();
            return conversorExtensao.ConverterNumero(numero);
        }

        public string RetornaResultadoMatematica(string expressao)
        {
            ValidacaoExpressao(expressao);
            ICalculoMatematico calculoMatematico = new CalculoMatematico();
            return calculoMatematico.Executar(expressao);
        }

        public int SomaNumerosArray(int[] numeros)
        {
            ValidacaoArrayNumeros(numeros);

            return numeros.Sum();
        }

        #endregion

        #region private methods

        private void ValidacaoListaColaboradores(IList<Colaborador> colaboradores)
        {
            throw new NotImplementedException();
        }

        private void ValidacaoNumero(ulong numero)
        {
            throw new NotImplementedException();
        }

        private void ValidacaoExpressao(string expressao)
        {
            throw new NotImplementedException();
        }

        private void ValidacaoArrayNumeros(int[] numeros)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
