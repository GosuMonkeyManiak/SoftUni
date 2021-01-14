using System;
using System.Collections.Generic;

namespace BalancedParantheses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string inPut = Console.ReadLine();

            Stack<string> brackets = new Stack<string>();

            for (int i = 0; i < inPut.Length; i++)
            {
                string currentBracket = inPut[i].ToString();

                if ((currentBracket == "}" || currentBracket == ")" || currentBracket == "]") && i == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }

                if (currentBracket == "{" || currentBracket == "}")
                {
                    if (currentBracket == "}")
                    {
                        string previousBracket = " ";

                        if (brackets.Count > 0) // is have at end close bracket afre all brackets and the stack is have to have nothing
                        {
                            previousBracket = brackets.Peek();
                        }
                        
                        if (previousBracket != "{")
                        {  
                            Console.WriteLine("NO");
                            return;
                        }

                        brackets.Pop();
                        continue;
                    }

                    brackets.Push(currentBracket);
                }
                else if (currentBracket == "(" || currentBracket == ")")
                {
                    if (currentBracket == ")")
                    {
                        string previousBracket = " ";

                        if (brackets.Count > 0)
                        {
                            previousBracket = brackets.Peek();
                        }

                        if (previousBracket != "(")
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        brackets.Pop();
                        continue;
                    }

                    brackets.Push(currentBracket);
                }
                else if (currentBracket == "[" || currentBracket == "]")
                {
                    if (currentBracket == "]")
                    {
                        string previousBracket = " ";

                        if (brackets.Count > 0)
                        {
                            previousBracket = brackets.Peek();
                        }

                        if (previousBracket != "[")
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        brackets.Pop();
                        continue;
                    }

                    brackets.Push(currentBracket);
                }


            }

            Console.WriteLine("YES");
        }
    }
}
