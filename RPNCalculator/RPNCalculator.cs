using System;

namespace RPNCalculator
{
    public class RpnCalculator
    {
        public int Compute(string command)
        {
            int result;
            if (int.TryParse(command, out result))
            {
                return result;
            }

            Operation operation;
            var remainingCommand = ParseCommand(command, out operation);

            while (remainingCommand.Length > 0)
            {
                remainingCommand = ParseCommand($"{ApplyOperation(operation)} {remainingCommand}", out operation);
            }

            return ApplyOperation(operation);
        }

        private int ApplyOperation(Operation operation)
        {
            int result;
            if (operation.Operator == '+')
            {
                result = Add(operation.Operands);
            }
            else if (operation.Operator == '-')
            {
                result = Minus(operation.Operands);
            }
            else if (operation.Operator == '*')
            {
                result = Multiply(operation.Operands);
            }
            else
            {
                result = Divde(operation.Operands);
            }
            return result;
        }

        private static string ParseCommand(string command, out Operation operation)
        {
            var operationMembers = command.Split(' ');
            
            var firstOperand = int.Parse(operationMembers[0]);
            var secondOperand = int.Parse(operationMembers[1]);

            operation = new Operation
            {
                Operands = new Operands
                {
                    FirstOperand = firstOperand,
                    SecondOperand = secondOperand,
                },
                Operator = Convert.ToChar(operationMembers[2])
            };

            if (operation.Operands.SecondOperand == 0 && operation.Operator == '/')
            {
                throw new ArgumentException();
            }

            return string.Join(" ", operationMembers, 3, operationMembers.Length-3);
        }

        private static int Add(Operands operands)
        {
            return operands.FirstOperand + operands.SecondOperand;
        }

        public static int Minus(Operands operands)
        {
            return operands.FirstOperand - operands.SecondOperand;
        }

        public static int Multiply(Operands operands)
        {
            return operands.FirstOperand * operands.SecondOperand;
        }

        private static int Divde(Operands operands)
        {
            return operands.FirstOperand / operands.SecondOperand;
        }
    }
}
