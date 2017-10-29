using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ADVANCED.ObjLifeTie
{
    class ResourcesClass4Pattern : IDisposable
    {

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ResourcesClass4Pattern() {
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

    }
    class ResourcesClass3 : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("RC3 - I clean unmanaged res in Dispose");
        }
        ~ResourcesClass3()
        {
            Console.WriteLine("RC3 - I clean unmanaged res in ~  Finalize");
        }
    }
    class ResourcesClass2 : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Czyszce Unmanaged resoures");
        }
    }
    class ResourcesClass1
    {
        
        public string MyProperty { get; set; }

        public void Something()
        {
            int y = 5 * 10;
            Console.WriteLine("y");
        }
       //NIE DA SIE!!!! protected override Finalize()
       ~ResourcesClass1()
        {
            Console.WriteLine("Tak sie da!!");
        }
    }
    class ObjLifeTime
    {
        public static void TestGC()
        {
            Console.WriteLine(GC.GetTotalMemory(false));

           

            ResourcesClass1 mc = new ResourcesClass1();
            mc.Something();
            mc = null;
            GC.Collect();
            GC.WaitForPendingFinalizers(); Console.WriteLine(GC.GetTotalMemory(false));
            using (ResourcesClass2 rc2 = new ResourcesClass2())
            {
                Console.WriteLine("rc2");
            }
            using (ResourcesClass3 rc3 = new ResourcesClass3())
            {
                Console.WriteLine("rc3");
               
            }
            ResourcesClass3 rc4 = new ResourcesClass3();
            rc4 = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
    }
}
