using System;

namespace ListyIterator
{
    public  class StartUp
    {
        static void Main(string[] args)
         {
            ListyIterator<string> list = new ListyIterator<string>();

            string[] inPut = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (inPut.Length > 1 && inPut[0].ToLower() == "create")
            {
                string[] element = new string[inPut.Length - 1];
                int index = 0;

                for (int i = 1; i < inPut.Length; i++)
                {
                    element[index] = inPut[i];
                    index++;
                }

                list.Create(element);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;

                    case "Print":
                        list.Print();
                        break;

                    case "PrintAll":
                        list.PrintAll();
                        break;
                }


            }

        }
    }
}
