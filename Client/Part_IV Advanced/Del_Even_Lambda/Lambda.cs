using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ADVANCED.Del_Even_Lambda
{
    class Lambda
    {
        public void Test()
        {
            var lista = Enumerable.Range(2, 20);
            bool AllGreaterThan10 = lista.All((x) => { return x > 10; });
            bool AllGreaterThan20 = lista.All((int x) => {  Console.Write("x > 10"); return x > 1;});
            foreach (var i in    lista.ToList().FindAll((X) => X > 10))
            {
                Console.Write(i + ", ");
            }

            Test2();

        }
        public void Test2() => Console.Write("Test2");
    }
}
