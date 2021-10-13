using System;

namespace Cons
{
    class Program
    {
        public bool Print(int i)
        {
            Console.WriteLine($"Ivan number {i} and have IQ ");
            return true;
        }
        public int Retur(string i)
        {
            Console.WriteLine($"Ivan number {i} and have IQ ");
            return 1;
        }
        public void Print(int i,int t)
        {
            Console.WriteLine($"Ivan number {i} and have IQ {100*t}");
        }
        static void Main(string[] args)
        {
            Program prog = new Program();
            Action<int,int> action = prog.Print;
            action.Invoke(1,2);
            Predicate<int> predicate = prog.Print;
            Func<string, int> func = prog.Retur;


            
            Console.ReadLine();


        }
    }

}