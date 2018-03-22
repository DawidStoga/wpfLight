using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Client.OOP.OOP_Encaps;
namespace Client.OOP
{
    partial class OOP_Inher_Poli
    {
        public static void AirplaneMethValue(AirPlane ap)
        {
            var pl = new AirPlane("a40");
            Console.WriteLine(AirPlane.uPlaneCnt);
        }
        public static void AirplaneMethRef(ref AirPlane ap)
        {
            Console.WriteLine(AirPlane.uPlaneCnt);
        }
        public static void OOP_Inheritance()
        {
            AirPlane a380_800 = new AirBusA380("A380", 800);
            AirPlane a380_400 = new AirBusA380("A380", 400);
            AirPlane a380_600 = new AirBusA380("A380", 600);
            Console.WriteLine(AirPlane.uPlaneCnt);
            Console.WriteLine("\n");
            AirplaneMethValue(a380_400);
            AirplaneMethValue(new AirPlane("A340"));
            AirplaneMethValue(a380_400);
            Console.WriteLine(AirPlane.uPlaneCnt);
            a380_400.Dispose();
            Console.WriteLine(AirPlane.uPlaneCnt);

            var arbus = a380_400 as AirBus;
            arbus.Start();
            (a380_800 as AirBus).Start();
            AbsClass abs = new DerAbsclass();
            abs.method2();
            abs.method1();

            if (abs is DerAbsclass)
            {
                (abs as DerAbsclass).method1();
            }
        }
        public static void systemObject()
        {
            BaseClass bs1 = new BaseClass();
            BaseClass bs2 = new BaseClass();
            BaseClass bs3 = bs1;
            Console.WriteLine("SystemObject Base class");
            Console.WriteLine("Vers1");

            Console.WriteLine("bs1.Equals(bs2):   {0}",bs1.Equals(bs2));//false
            Console.WriteLine("bs1.Equals(bs3): {0}", bs1.Equals(bs3));//true
            bs1.EqualVer2 = true;
            Console.WriteLine("Vers2");
            Console.WriteLine(bs1.Equals(bs2));//true
            Console.WriteLine(bs1.Equals(bs3));//true

            bs1.MyOldProp = 47;

            var bsnew = (BaseClass)bs1.Clone();
            Console.WriteLine(bsnew.MyOldProp);

            Console.WriteLine(object.Equals(bs1, bs2));
            Console.WriteLine(object.ReferenceEquals(bs1, bs3));



        }


    }
}
