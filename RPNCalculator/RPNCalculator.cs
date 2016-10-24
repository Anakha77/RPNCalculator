using System;
using System.Linq;

namespace RPNCalculator
{
    public class RpnCalculator
    {
        public int Compute(string command)
        {
            var listElements = command.Split(' ').ToList();

            for (var i = 0; i < listElements.Count; i++)
            {
                if (!IsOoperator(listElements[i])) continue;

                var operand1 = int.Parse(listElements[i - 2]);
                var operand2 = int.Parse(listElements[i - 1]);
                var @operator = listElements[i];

                listElements.RemoveRange(i - 2, 3);
                listElements.Insert(i - 2, ApplyOperator(operand1, operand2, @operator).ToString());
                i = i - 2;
            }

            return int.Parse(listElements[0]);
        }

        private static bool IsOoperator(string element)
        {
            var operators = new[] {"+", "-", "*", "/"};
            return operators.Any(o => o == element);
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
