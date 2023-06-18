using TestePorter.Classes;
using TestePorter.Enums;

Console.WriteLine("------------------------------------------------\n");
Console.WriteLine("Teste Porter\r");
Console.WriteLine("------------------------------------------------\n");

var conversor = new Conversor();
var descricoes = conversor.RetornaDescricoes();

foreach (var item in descricoes)
{
    Console.WriteLine(item);
}

Console.WriteLine("------------------------------------------------\n");

var operacao = Console.ReadLine();
Enum.TryParse(operacao, out Operacao value);
conversor.OperacaoEscolhida = value;

Console.WriteLine("------------------------------------------------\n");

var instrucao = conversor.RetornaInstrucao();

Console.WriteLine(instrucao);
var parametros = Console.ReadLine();

switch (parametros)
{
    default:
        break;
}


Console.WriteLine("------------------------------------------------\n");







