using System;

namespace RefactorTest
{
    class MultiplyResult
    {
        public bool IsDivisible;
        public int MultiplyOperationResult;
    }
    class MultiplyOperation
    {
        private readonly int x;
        private readonly int x2;

        public MultiplyOperation(int x, int x2)
        {
            this.x = x;
            this.x2 = x2;
        }

        public MultiplyResult GetResult()
        {
            return new MultiplyResult
            {
                IsDivisible = this.x * this.x2 % 5 == 0,
                MultiplyOperationResult = this.x * this.x2,
            };
        }
    }
    
    class SumResult
    {
        public bool IsDivisible;
        public int SumOperationResult;
    }
    class SumOperation
    {
        private readonly int x;
        private readonly int x2;

        public SumOperation(int x, int x2)
        {
            this.x = x;
            this.x2 = x2;
        }

        public SumResult GetResult()
        {
            return new SumResult
            {
                IsDivisible = (this.x + this.x2) % 5 == 0,
                SumOperationResult = this.x + this.x2,
            };
        }
    }
    
    class DivisionResult
    {
        public bool IsDivisible;
        public int DivisionOperationResult;
    }
    class DivisionOperation
    {
        private readonly int x;
        private readonly int x2;

        public DivisionOperation(int x, int x2)
        {
            this.x = x;
            this.x2 = x2;
        }

        public DivisionResult GetResult()
        {
            return new DivisionResult
            {
                IsDivisible = this.x / this.x2 % 5 == 0,
                DivisionOperationResult = this.x / this.x2,
            };
        }
    }
    
    class SubtractResult
    {
        public bool IsDivisible;
        public int SubtractOperationResult;
    }
    class SubtractOperation
    {
        private readonly int x;
        private readonly int x2;

        public SubtractOperation(int x, int x2)
        {
            this.x = x;
            this.x2 = x2;
        }

        public SubtractResult GetResult()
        {
            return new SubtractResult
            {
                IsDivisible = (this.x - this.x2) % 5 == 0,
                SubtractOperationResult = this.x - this.x2,
            };
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number:");
            var x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number:");
            var x2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Result:");
            var y = AllSuccess(x, x2);
            if (y == true)
            {
                Console.WriteLine("All Operations on '" + x + "' and '" + x2 + "' are divisible by 5");    
            }
            else
            {
                Console.WriteLine("Not all Operations on '" + x + "' and '" + x2 + "' are divisible by 5");
            }
            
            Console.ReadLine();
        }

        private static bool AllSuccess(int x, int x2)
        {
            // return true if x+x2 and x-x2 and x*x2 and x/x2 are all divisible by 5
            var sumResult = new SumOperation(x, x2).GetResult();
            var mulResult = new MultiplyOperation(x, x2).GetResult();
            var divResult = new DivisionOperation(x, x2).GetResult();
            var subResult = new SubtractOperation(x, x2).GetResult();
            
            if (sumResult.IsDivisible)
            {
                if (mulResult.IsDivisible)
                {
                    if (divResult.IsDivisible)
                    {
                        if (subResult.IsDivisible)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine(subResult.SubtractOperationResult + " is not divisible by 5");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine(divResult.DivisionOperationResult + " is not divisible by 5");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine(mulResult.MultiplyOperationResult + " is not divisible by 5");
                    return false;
                }
            }
            else
            {
                Console.WriteLine(sumResult.SumOperationResult + " is not divisible by 5");
                return false;
            }
        }
    }
}