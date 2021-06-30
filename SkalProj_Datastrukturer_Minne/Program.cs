using System;
using System.Collections;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            //svar:
            // 1. Stacken är minnet som används av programmtråden för att hålla lokala data i en funktion och tas bort direkt när funktionen körts
            // stacken är ordnad som en först in först ut struktur.
            // Heapen är till för att lagra dynamisk data, te.x när du allokerar en objectinstans med 'new', detta minne hanteras i c# av en garbage collector
            // som ansvarar för att orefererat minne friges och ev deframentation.
            // 2. Value type är en typ som är ett värde direkt, referens type är en referens som pekar på en minnesplats där värdet finns.
            // 3. Den första retunerar 3 för att x tilldelas värdet 3 och retuners senare, den andra så tilldelas y samma referens som x, därmed ändras både x,y när y ändras ->4 retuneras



            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n5. The Recursion thing"
                    + "\n6. The Iteration thing"
                    + "\n7. Reverse"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        Recursion();
                        break;
                    case '6':
                        Iteration();
                        break;
                    case '7':
                        Reverse();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        private static void Iteration()
        {
            


            Console.WriteLine("Iterative even?");
            string line = Console.ReadLine();

            int n = 0;
            int.TryParse(line, out n);

            Console.WriteLine($"The {n}'th even number is {IterativeEven(n)}");


            Console.WriteLine("Fibonnaci Iteration?");
            line = Console.ReadLine();

            n = 0;
            int.TryParse(line, out n);


            Console.WriteLine($"The {n}'th fibonnacci number is {IterativeFibon(n)}");



        }

        private static int IterativeEven(int n)
        {
            int output = 0;
            for (int i = 0; i < n; i++)
            {
                output+=2;
            }

            return output;
        }

        private static int IterativeFibon(int n)
        {
            // svar. en iterativ lösning använder betydligt minder stackminne då den endast körs ifrån en metod
            // en rekursiv behöver lagra ett helt träd med metoddata på stacken

            int[] array = new int[3];
            array[1] = 1;
            array[2] = 1;

            for (int i = 0; i < n-2; i++)
            {
                array[0] = array[1];
                array[1] = array[2];
                array[2] = array[0] + array[1];

            }
            return array[2];
        }

        private static void Recursion()
        {
            

            Console.WriteLine("Recursive even?");
            string line = Console.ReadLine();

            int n = 0;
            int.TryParse(line, out n);

            Console.WriteLine($"The {n}'th even number is {RecursiveEven(n)}");


            Console.WriteLine("Fibonnaci Recursive?");
            line = Console.ReadLine();

            n = 0;
            int.TryParse(line, out n);


            Console.WriteLine($"The {n}'th fibonnacci number is {Fibon(n)}");

        }

        private static int RecursiveEven(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            return (RecursiveEven(n-1)+2);
        }

        private static int Fibon(int n)
        {
            
            if (n <= 2)
            {
                return 1;
            }
            return Fibon(n-1) + Fibon(n-2);
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}

            //ExamineCollection<List<string>>();



            List<string> list = new List<string>();
            list.Examine();   // en extension metod i separat fil

            // 2. listans capacitet ökar när det finns mer element än kapacitet
            // 3. en dubblering
            // 4. för att det tar tid att allokera en ny array och kopiera över den den gamla till den ny samt radera den gamla
            // 5. Nej, inte automatiskt.
            // 6. När man har en förutsägbar storlek.

            

        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> queue = new Queue<string>();
            queue.Examine();
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Stack<string> stack = new Stack<string>();
            stack.Examine();

        }

        static void Reverse()
        {
            Console.WriteLine("Type something to be reversed:");
            string line = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            char[] charArray = line.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                stack.Push(charArray[i]);
            }

            while(stack.Count!=0)
            {
                Console.Write(stack.Pop());
            }
            Console.Write("\n");
        }


        static void CheckParanthesis()
        {
            // Här har jag använt mig av en rekursion, jag missade instruktionerna litegrann
            // Då det är olika nivåer av instruktioner i kommentarerna vs övningsbeskrivningen
            // Men eftersom en rekursion kan betraktas som en stack typ av datastruktur är det ok iaf.
            // funktionen delar dessutom upp resten av strängen som förberedelse för vidare tolkning.

            Console.WriteLine("Type a line to check if paranthesis is correct");

            string line = Console.ReadLine();

            try
            {
                Console.WriteLine("------------------------------------------------------------------");
                Para(line.AsSpan(), 0, ' ', 0);
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("everything is fine!");
            }
            catch(Exception e)
            {                
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("------------------------------------------------------------------");
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

        static int Para(ReadOnlySpan<char> span, int index, char expectedParantes, int level)
        {
            // använder en span? en indexposition för att göra det lite minnesvänligare
            // har också satt in en levelparameter som inte behövs men det kan vara intressant
            // vid vidare utvecking av syntaxträdet

            Console.WriteLine("at level "+level+ "  parantesis "+expectedParantes);
            int start = index;
            while(index<span.Length)
            {                
                switch (span[index])
                {
                    case ']':                             
                    case '}':                                         
                    case '>':                                          
                    case ')':
                        if (expectedParantes != span[index])
                        {
                            throw new ArgumentException("Parantes missmatch at position "+index);
                        }
                        // text innom paranteser
                        Console.WriteLine("internal:" + span.Slice(start, index - start).ToString());
                        return index;
                    


                    case '[':
                    case '{':
                    case '<':
                    case '(':
                        // text före en parantes
                        Console.WriteLine("external:" +span.Slice(start, index - start).ToString());
                        index = Para(span, index + 1, GetMatchingParantes(span[index]), level+1);
                        start = index+1;
                        break;
                    
                        
                
                }                
                index++;
            }

            if (expectedParantes != ' ')
            {
                // när det finns "öppna paranteser när strängen är slut"
                throw new ArgumentException("Missing parantes at position " + index);                
            }
            if (start < span.Length)
            {     
                // ev text i slutet av strängen
                Console.WriteLine("at level " + level + "  parantesis " + expectedParantes);
                Console.WriteLine("last:" + span.Slice(start).ToString());
            }

            return index;
        }

        // hjälpmetod till Para
        private static char GetMatchingParantes(char input)
        {
            switch (input)
            {
                case '[':
                    return ']';                    
                case '{':
                    return '}';                    
                case '<':
                    return '>';                    
                case '(':
                    return ')'; 
            }
            return ' ';
        }


        

        

    }
}

