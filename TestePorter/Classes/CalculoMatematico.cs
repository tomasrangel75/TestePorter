using TestePorter.Exceptions;
using TestePorter.Interfaces;

namespace TestePorter.Classes
{
    public class CalculoMatematico : ICalculoMatematico
    {
        public string Executar(string expressaoMatematica)
        {
            var stack = new Stack<string>();

            var value = "";
            for (int i = 0; i < expressaoMatematica.Length; i++)
            {
                string s = expressaoMatematica.Substring(i, 1);
                char chr = s.ToCharArray()[0];

                if (!char.IsDigit(chr) && chr != '.' && value != "")
                {
                    stack.Push(value);
                    value = "";
                }

                if (s.Equals("("))
                {

                    string innerExp = "";
                    i++;
                    int bracketCount = 0;
                    for (; i < expressaoMatematica.Length; i++)
                    {
                        s = expressaoMatematica.Substring(i, 1);

                        if (s.Equals("("))
                            bracketCount++;

                        if (s.Equals(")"))
                            if (bracketCount == 0)
                                break;
                            else
                                bracketCount--;


                        innerExp += s;
                    }

                    stack.Push(Executar(innerExp).ToString());

                }
                else if (s.Equals("+")) stack.Push(s);
                else if (s.Equals("-")) stack.Push(s);
                else if (s.Equals("*")) stack.Push(s);
                else if (s.Equals("/")) stack.Push(s);
                else if (s.Equals("sqrt")) stack.Push(s);
                else if (s.Equals(")"))
                {
                }
                else if (char.IsDigit(chr) || chr == '.')
                {
                    value += s;

                    if (value.Split('.').Length > 2)
                        throw new InvalidInputException("Decimal inválido.");

                    if (i == expressaoMatematica.Length - 1)
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

            return $"{expressaoMatematica} = {resultadoFinal}";
        }
    }

}
