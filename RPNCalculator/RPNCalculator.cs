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

        private static int ApplyOperation(Operation operation)
        {
            return operation.GetOperationResult();
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
    }
}
