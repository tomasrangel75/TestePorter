using TestePorter.Classes;
using TestePorter.Enums;

bool endApp = false;

Console.WriteLine("------------------------------------------------\n");
Console.WriteLine("Teste Porter\n");
Console.WriteLine("------------------------------------------------\n");

var conversor = new Conversor();
var descricoes = conversor.RetornaDescricoes();


while (!endApp)
{

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
    dynamic parametros = Console.ReadLine();

    Console.WriteLine("\n");

    dynamic? result = null;

    switch (conversor.OperacaoEscolhida)
    {
        case Operacao.RemoveObjetosRepetidos:
            result = conversor.RemoveObjetosRepetidos(parametros);
            break;
        case Operacao.RetornaNumeroPorExtenso:
            result = conversor.RetornaNumeroPorExtenso(Convert.ToUInt32(parametros));
            break;
        case Operacao.RetornaResultadoMatematica:
            result = conversor.RetornaResultadoMatematica(parametros);
            break;
        case Operacao.SomaNumerosArray:
            result = conversor.SomaNumerosArray(parametros);
            break;
        default:
            break;
    }

    Console.WriteLine(result);

    Console.WriteLine("------------------------------------------------\n");

    // Wait for the user to respond before closing.
    Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
    if (Console.ReadLine() == "n") endApp = true;

    Console.WriteLine("\n"); // Friendly linespacing.
}

return;




