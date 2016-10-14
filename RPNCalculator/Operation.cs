
namespace RPNCalculator
{
    public class Operation
    {
        public Operands Operands { get; set; }
        public char Operator { get; set; }

        public int GetOperationResult()
        {
            int result;
            switch (Operator)
            {
                case '+':
                    result = Add(Operands);
                    break;
                case '-':
                    result = Minus(Operands);
                    break;
                case '*':
                    result = Multiply(Operands);
                    break;
                default:
                    result = Divde(Operands);
                    break;
            }

            return result;
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
