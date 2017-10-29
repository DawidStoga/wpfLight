using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.OOP
{
   partial  class OOP_Encaps
    {

        public static void Oop()
        {
            BaseClass bs = new BaseClass();
            bs.MethodNorm();
            bs.MethodVirt();

            Console.WriteLine(Environment.NewLine);

            DerivedClass_Level2 dc1 = new DerivedClass_Level2();
            dc1.MethodNorm();
            dc1.MethodVirt();

            Console.WriteLine(Environment.NewLine);

            BaseClass bsd = new DerivedClass_Level2();
            bsd.MethodNorm();
            bsd.MethodVirt();

            Console.WriteLine(" bsd : {0}", bsd.GetType());


            DerivedClass_Level2 dc = bsd as DerivedClass_Level2;
            dc.MethodNorm();
            Console.WriteLine(" dc: {0}", dc.GetType());

            Console.WriteLine(Environment.NewLine);


            dc.MyOldProp = dc.ReadOnlyProp;
            dc.MyOldProp = dc.ReadOnlyProp;
            dc.MyOldProp = dc.ReadOnlyProp;
            dc.MyOldProp = dc.ReadOnlyProp;

            BaseClass bsAssigned = new BaseClass { MyOldProp = 2, toAssign1 = 2, toAssign2 = 3 };
            bsAssigned.Display();

        }
  
       internal abstract class AbsClass
        {
            int a;
            public AbsClass()
            {
                Console.WriteLine("Base abstract");
            }
            public void method1()
            {
                Console.WriteLine("Meth1");
            }
            public abstract int method2();
        }
        internal class DerAbsclass : AbsClass
        {
            public DerAbsclass()
            {
                Console.WriteLine("derAbsrt");
            }
            public override int method2()
            {
                Console.WriteLine("Abstract derived ");
                return 0;
            }
            public new void method1()
            {
                Console.WriteLine("METH1");
            }
        }

        internal class BaseClass : ICloneable
        {
            public bool EqualVer2;
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                if (EqualVer2) return this.MyProperty.Equals((obj as BaseClass).MyProperty);
                else
                    return base.Equals(obj);
            }

            static BaseClass()
            {
                staticreadOnly = 4;
            }
            public BaseClass()
            {
                Console.WriteLine("ctror");
                readOnly = 9;
            }

            public const int myConst = 2;
            readonly int readOnly;
            static readonly int staticreadOnly;
            public int toAssign1;
            public int toAssign2;
            public int toAssign3 { set; get; }
            public int MyProperty { get; set; } = 5;
            private int intProp;
            public int MyOldProp
            {
                get { return intProp; }
                set
                {
                    intProp = value;
                    Console.WriteLine("SET {0} executed", value);
                }
            }

            public int ReadOnlyProp
            {
                get { intProp++; return intProp; }
            }


            public void MethodNorm()
            {
                Console.WriteLine("Method_Norm  BASE:  prop {0}", MyProperty);
            }

            public virtual void MethodVirt()
            {
                Console.WriteLine("Method_Virt  BASE:  prop {0}", MyProperty);
            }

            internal void Display()
            {
                Console.WriteLine($"toAssign1 = {toAssign1} toAssign2 = {toAssign2} toAssign3 = {toAssign3}  ");
            }

            public object Clone()
            {
                return MemberwiseClone();
            }


            // public abstract void BaseAbstrMethid(); only in abstract class
        }

        class DerivedClass_Level2 : BaseClass
        {
            public override void MethodVirt()
            {
                Console.WriteLine("MethodVirt DERIVED:  prop {0}", MyProperty);
            }
            public new void MethodNorm()
            {
                Console.WriteLine("Method_Norm DERIVED:  prop {0}", MyProperty);
            }
        }
        sealed class DerivedClass2 : BaseClass
        {

        }

        /* class Derived3Level:DerivedClass2  Error
         {

         }*/

        struct BaseStruct
        {

        }

        //struct derivedstruct:basestruct       Error - struct are implicitly sealed
        //{

        //}
        //struct derivedStruct:BaseClass     Error
        //{   


        //}


       internal class AirPlane : IDisposable
        {
            static public UInt16 uPlaneCnt { get; private set; }

            protected string sPlaneName;
            private string sEngineNr;
            public AirPlane(string name)
            {
                uPlaneCnt++;
                sPlaneName = String.Concat("Plane : ", name);
                Console.WriteLine("Airplane ctr  -  {0,21}", sPlaneName);

            }
            #region IDisposable Support
            private bool disposedValue = false; // To detect redundant calls

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects).
                        if (uPlaneCnt != 0) uPlaneCnt--;
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                    // TODO: set large fields to null.

                    disposedValue = true;
                }
            }

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            // ~AirPlane() {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            //   Dispose(false);
            // }

            // This code added to correctly implement the disposable pattern.
            public void Dispose()
            {
                // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                Dispose(true);
                // TODO: uncomment the following line if the finalizer is overridden above.
                // GC.SuppressFinalize(this);
            }
            #endregion
            protected virtual void TakeOff()
            {
                Console.WriteLine("AirPlane takes off");
            }
        }
       internal class AirBus : AirPlane
        {
            public AirBus(string s) : base(s)
            {
                sPlaneName = sPlaneName.Insert("Plane : ".Length, "AirBus ");

                Console.WriteLine("AirBus ctr  -  {0,30}", sPlaneName);
            }
            protected sealed override void TakeOff()
            {
                Console.WriteLine("AirBus takes off");
                base.TakeOff();
            }
            public void Start()
            {
                this.TakeOff();

            }

        }
       internal class AirBusA380 : AirBus
        {
            public AirBusA380(string name, int version) : base(name)
            {


                sPlaneName += ("-" + version);
                Console.WriteLine("AirBusa380 ctr  -  {0,30}", sPlaneName);
            }

        }


    }
}
