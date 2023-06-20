using TestePorter.Exceptions;
using TestePorter.Interfaces;

namespace TestePorter.Classes
{
    public class CalculoMatematico : ICalculoMatematico
    {
        public string Executar(string expressao)
        {
            var stack = new Stack<string>();

            var value = "";
            for (int i = 0; i < expressao.Length; i++)
            {
                string s = expressao.Substring(i, 1);
                char chr = s.ToCharArray()[0];

                if (!char.IsDigit(chr) && value != "")
                {
                    stack.Push(value);
                    value = "";
                }

                if (s.Equals("+")) stack.Push(s);
                else if (s.Equals("-")) stack.Push(s);
                else if (s.Equals("*")) stack.Push(s);
                else if (s.Equals("/")) stack.Push(s);
                else if (char.IsDigit(chr))
                {
                    value += s;
                    if (i == expressao.Length - 1)
                        stack.Push(value);
                }
                else
                    throw new InvalidInputException("Caracter inválido.");

            }

            double result = 0;
            while (stack.Count >= 3)
            {

                double right = Convert.ToDouble(stack.Pop());
                string op = stack.Pop();
                double left = Convert.ToDouble(stack.Pop());

                if (op == "+") result = left + right;
                else if (op == "+") result = left + right;
                else if (op == "-") result = left - right;
                else if (op == "*") result = left * right;
                else if (op == "/") result = left / right;

                stack.Push(result.ToString());
            }

            var resultadoFinal = Convert.ToDouble(stack.Pop());

            return $"{expressao} = {resultadoFinal}";
        }
    }

}
