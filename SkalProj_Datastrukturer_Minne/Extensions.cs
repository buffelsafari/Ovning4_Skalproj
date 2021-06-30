using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    

    static class Extensions
    {        
        private static readonly Dictionary<Type, string[]> dictionary;
        
        private delegate int Capacity();
        private delegate void Add(string str);
        private delegate string Remove();
        private delegate bool RemoveItem(string str);

        static Extensions()
        {           
            
            dictionary = new Dictionary<Type, string[]>();

            dictionary.Add(typeof(Remove), new string[]{ "Dequeue", "Pop" });
            dictionary.Add(typeof(RemoveItem), new string[] { "Remove" });
            dictionary.Add(typeof(Add), new string[] { "Add", "Enqueue", "Push" });
            dictionary.Add(typeof(Capacity), new string[] { "get_Capacity" });
        }

        public static void Examine(this ICollection collection)
        {
            // försökte mig på att abstraktisera övning 1,2,3
            // men det blev knasigare än väntat då de olika collectionerna inte var så lika som jag först trodde
            // använder reflection för att tilldela delegaterna collectionernas funktionalitet
            

            Capacity capacity= collection.AssignDelegate<Capacity>(dictionary);
            Add add= collection.AssignDelegate<Add>(dictionary);
            RemoveItem removeItem= collection.AssignDelegate<RemoveItem>(dictionary);
            Remove remove=collection.AssignDelegate<Remove>(dictionary);

            ShowCommands();

            bool isRunning = true;
            while (isRunning)
            {

                int? cap = capacity?.Invoke();
                Console.Write($"the collection contains {collection.Count} elements");
                if (cap != null)
                {
                    Console.Write($" and the capacity is {cap} elements");
                }
                Console.Write(".\n");


                string line = Console.ReadLine();
                char nav = '0';
                if (line.Length > 0)
                {
                    nav = line[0];
                    line = line[1..];
                }

                switch (nav)
                {
                    case '+':
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            add?.Invoke(line);
                        }
                        break;
                    case '-':
                        if (collection.Count>0)
                        {
                            remove?.Invoke();
                            removeItem?.Invoke(line);
                        }
                        break;
                    case 'q':   // use 'q' to exit to main menu
                        isRunning = false;
                        break;
                    case 's':
                        foreach (string s in collection)
                        {
                            Console.WriteLine(s);
                        }
                        break;
                    default:
                        ShowCommands();
                        break;

                }
            }            
        }

        private static void ShowCommands()
        {
            Console.WriteLine("use +, -, s or q");
        }

        // skapar ett delegat från en ICollection av typen T, använder en dictonary för att hitta lämplig metod
        private static T AssignDelegate<T>(this ICollection collection, Dictionary<Type, string[]> dict) where T:Delegate
        {
            string[] arr;
            dict.TryGetValue(typeof(T), out arr);


            foreach (string name in arr)
            {
                MethodInfo methodInfo = collection.GetType().GetMethod(name);
                if (methodInfo != null)
                {                    
                    return (T)methodInfo.CreateDelegate(typeof(T), collection);
                }
            }
            return null;
        }




       

    }
}
