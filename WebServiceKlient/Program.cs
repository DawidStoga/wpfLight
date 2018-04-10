using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceKlient.localhost;

namespace WebServiceKlient
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            int b = 5;
            var ws = new MathService();
            ws.UserAuthValue = new UserAuth() { UserName = "Odyn", Password = "itcraftsman" };
            var wynik = ws.Multiply(a, b);
            Console.WriteLine(wynik);

            Console.ReadKey();
        }
    }
}
