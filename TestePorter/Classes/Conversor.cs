using TestePorter.Enums;
using TestePorter.Interfaces;

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
  
        public IList<object> RemoveObjetosRepetidos(IList<object> objetos)
        {
            throw new NotImplementedException();
        }

        public string RetornaNumeroPorExtenso(ulong numero)
        {
            var conversorExtensao = new ConversorExtensao();
            return conversorExtensao.ConverterNumero(numero);
        }

        public int RetornaResultadoMatematica(string expressao)
        {
            throw new NotImplementedException();
        }

        public int SomaNumerosArray(int[] numeros)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
