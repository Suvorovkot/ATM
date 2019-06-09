using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    class Program
    {
        static List<int> NominalValues;

        static List<int> Validate(List<int> collection) => collection.Distinct().ToList();

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Banknote: ");
                    var Note = Validate(Console.ReadLine());

                    NominalValues = new List<int>();
                    Console.WriteLine("Available values: ");
                    var v = Validate(Console.ReadLine());
                    while (v != 0)
                    {
                        NominalValues.Add(v);
                        v = Validate(Console.ReadLine());
                    }

                    NominalValues = Validate(NominalValues);
                    Exchange(Note, 0, "");
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch
                {
                    Console.WriteLine("Wrong input");
                }
            }

        }

        public static bool IsValid(int x)
        {
            return x > 0;
        }

        public static int Validate(String x)
        {
            int IntX;
            try
            {
                IntX = int.Parse(x);
            }
            catch
            {
                throw new ArgumentException("Wrong input: " + x);
            }
            if (!IsValid(IntX)) throw new ArgumentException("Wrong input: " + x);
            return IntX;
        }

        public static void Exchange(int Note, int pos, string Result)
        {
            if (Note == 0)
                Console.WriteLine(Result);
            else
            {
                if (pos < NominalValues.Count)
                {
                    for (int i = Note / NominalValues[pos]; i > 0; i--)
                    {
                        string Temp = Result;
                        for (int k = 0; k < i; k++)
                        {
                            Temp += NominalValues[pos] + " ";
                        }
                        Exchange(Note - i * NominalValues[pos], pos + 1, Temp);
                    }
                    Exchange(Note, pos + 1, Result);
                }
            }
        }

    }
}
