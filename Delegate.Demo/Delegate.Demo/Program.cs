using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using  Fun = System.Func<int, int, int>;

namespace Delegate.Demo
{
    class Program
    {
        public delegate int AddDelegate(int i, int j);
        delegate void Logdelegate();
        static void Main(string[] args)
        {
            AddDelegate ad = (a, b) =>
            {
               int c= a + b;
               return c + 4;
            };
            Console.WriteLine(ad(1, 1));

            AddDelegate ad2 = new AddDelegate((l, m) => l + m);
            Console.WriteLine(ad2(5, 1));

            Logdelegate ld = () =>
            {
                Console.WriteLine("Loggded using Delegare");
            };

            ld();

           

             Func <int, int, int> addFunc = (i, j) => i + j;
            Add(1, 2, addFunc);
            Console.ReadKey();
        }

       static int Add(int i,int j, Func<int,int,int> addFunc)
        {
            return addFunc(i, j);
        }
    }
}
