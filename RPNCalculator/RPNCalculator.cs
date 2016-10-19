using System;

namespace RPNCalculator
{
    public class RpnCalculator
    {
        public int Compute(string command)
        {
            var elements = command.Split(' ');

            if (elements.Length == 1)
            {
                return int.Parse(elements[0]);
            }


            var operand1 = int.Parse(elements[0]);
            var operand2 = int.Parse(elements[1]);
            var @operator = elements[2];

            return ApplyOperator(operand1, operand2, @operator);
        }

        private static int ApplyOperator(int operand1, int operand2, string @operator)
        {
            switch (@operator)
            {
                case "+":
                    return operand1 + operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    if (operand2 == 0)
                    {
                        throw new ArgumentException();
                    }
                    return operand1 / operand2;
                default:
                    return operand1 - operand2;
            }
        }
    }
}
