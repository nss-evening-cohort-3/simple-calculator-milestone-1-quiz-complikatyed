﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> leftList = new List<int>();
            int counter = 0;

            Console.WriteLine("CALCULATE ALL THE THINGS!");

            bool goAgain = true;
            Stack stack = new Stack();
            string lastQuery = "No query made yet";


            while (goAgain)  // This loop allows the user to continue playing
            {
                string prompt = "[" + counter + "]> ";

                Console.Write(prompt);
                string userRequest = Console.ReadLine().ToLower();

                if (userRequest == "quit" || userRequest == "exit") // IF USER CHOOSES TO QUIT THE CALCULATOR
                {
                    goAgain = false;
                    Console.WriteLine("Thanks for letting me calculate your things!");
                    Console.ReadLine();
                    return;
                }
                else if (userRequest == "lastq")
                {
                    Console.WriteLine("The last query was " + stack.getLastQuery());
                    counter = counter + 1;
                }
                else if (userRequest == "last")
                {
                    Console.WriteLine("The last answer was " + stack.getLastAnswer());
                    counter = counter + 1;
                }
                else
                {
                    lastQuery = stack.storeLastQuery(userRequest);
                    Console.WriteLine("You asked me to calculate " + userRequest);
                    Expression expression = new Expression();
                    Evaluate evaluate = new Evaluate();

                    // Checks to see if the operator and the left hand operand are both viable

                    bool calculate = true;

                    while (calculate)
                    {
                        try
                        {
                            int expressionAnswer = evaluate.getAnswer(
                                expression.convertString(expression.getLeft(userRequest)),
                                expression.convertString(expression.getRight(userRequest)
                                ), expression.getOperator(userRequest));

                            lastQuery = stack.storeLastQuery(userRequest);

                            int lastAnswer = stack.storeLastAnswer(expressionAnswer);
                            Console.WriteLine("The answer is: " + expressionAnswer);
                            calculate = false;
                            counter = counter + 1;

                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                            calculate = false;
                        }

                    }

                }

            }
            Console.WriteLine("");
        }
    }
}

