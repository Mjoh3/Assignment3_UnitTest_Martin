using System;

namespace Calculator_project
{
    public class Program
    {
        //My variables are declared outside of main all of them get default values in order to not cause any problems
        public static double result = 0;
        public static string mess = "";
        public static double num1 = 1, num2 = 1;//to avoid problems the numbers that I will calculate with are not set to 0 by default
        public static string oper = "";
        public static string inputnumber = "";
        public static bool validinput = false;
        public static void Main(string[] args)
        {
            //in order to run it multiple time I need to use a loop, I will run it as long as the variable is not q or Q, 
            //the default value is not q or Q so it will run for sure for at least once
            while (mess != "q" && mess != "Q")
            {
                //ask for first value (I used the read function to reuse it multiple times and to save space in the main function 
                //and to minimize repeating in the code)
                Console.WriteLine("Enter first number, then press enter");
                ReadAndEnsure(ref num1);
                //i ask for the operator, the ReadAndEnsure method is overwritten for the operator method with no parameters
                Console.WriteLine("Enter operation (+,-,*,/), then press enter");
                ReadAndEnsure();
                //ask for the second value passing a different variable
                Console.WriteLine("Enter next number, then press enter");
                ReadAndEnsure(ref num2);
                //run the calculations depending on the operator input plus minus multi or divide
                switch (oper)
                {
                    case "+":
                        Plus(num1, num2);

                        break;
                    case "-":
                        Minus(num1, num2);

                        break;
                    case "*":
                        Multi(num1, num2);

                        break;
                    case "/":
                        Divide(num1, num2);

                        break;
                    //if default case is showed, something is wring with the program as I have earlier checks to ensure
                    //that I have valid inputs
                    default:
                        Console.WriteLine("Something went wrong with the calculation");
                        break;
                }
                //show the calculation if you didnt divide by 0
                if (!(num2 == 0 && oper == "/"))
                    Console.WriteLine(num1 + " " + oper + " " + num2 + " = " + result);

                //ask if opponent wants to quit, "mess" will be modified, so if it is no longer q or Q the while loop will break
                Console.WriteLine("Do you want to quit? press q or Q and enter, othervise enter any other message, then enter");
                mess = Console.ReadLine();
            }


        }
        //this method is used to read the value of the numbers, my parameter is a reference in order 
        //to modify the variable in my parameter, which in this case will be num1 and num2
        public static void ReadAndEnsure(ref double num)
        {
            //a do while will make sure that the sequence runs at least once
            do
            {
                inputnumber = Console.ReadLine();
                //I use try to convert and if it was successful, the valid input will be true
                try
                {
                    num = double.Parse(inputnumber);
                    validinput = true;
                }
                //othervise the number is invalid and I will have to try again 
                catch
                {
                    Console.WriteLine("not a valid number");
                    validinput = false;
                }//if the validinput is false I will have to try again
            } while (validinput == false);

        }
        //without arguments readandinsure will work on the operator. 
        public static void ReadAndEnsure()
        {
            //valid input is set to false sand an input variable to read the op will be created
            string input = "";
            validinput = false;
            //a do while will make sure that the sequence runs at least once
            do
            {//read the operator value
                input = Console.ReadLine();
                //check if it is one of the allowed operators(+-/*)
                if (input == "+" || input == "-" || input == "/" || input == "*")
                    validinput = true;
                else
                    validinput = false;
                //if it is not it will notify the user...
                if (validinput == false)
                    Console.WriteLine("Not a valid operation (+,-,*,/) are valid operations");

                //...and let the user repeat the cycle
            } while (validinput == false);
            //the operator value will be a valid operator
            oper = input;
        }
        //add two numbers together

        
        public static void Plus(double a, double b)
        {
            result = a + b;
        }
        public static void Plus(double[] aArray)
        {
            result = 0;
            for (int i=0; i<aArray.Length; i++)
            {
                result += aArray[i];
            }
        }
        //subtract two numbers with each other
        public static void Minus(double a, double b)
        {
            result = a - b;
        }
        public static void Minus(double[] aArray)
        {
            result = 0;
            for (int i = 0; i < aArray.Length; i++)
            {
                result -= aArray[i];
            }
        }
        //multiply two numbers together
        public static void Multi(double a, double b)
        {
            result = a * b;
        }
        //divide two numbers if the second one is not 0
        public static bool dividedbyzero = false;
        public static void Divide(double a, double b)
        {
            if (b != 0)
            {
                result = a / b;
                dividedbyzero = false;
            }
            else
            {
                dividedbyzero = true;
                Console.WriteLine("Can not divide by 0");
            }
                //notify user if second number is 0
        }
    }
}
