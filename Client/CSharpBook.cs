using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Client.CoreCSProgramming;
using Client.OOP;
using Client.ADVANCED.CollectionsAndGeneric;
using Client.ADVANCED;
using Client.Assemblies;
using Client.BaseLibrary;
using System.IO;

namespace Client
{
    partial class CSharpBook
    {

        enum ExerciceItem
        {
         eCorePart1 =  1,
         eCorePart2 =  2,
         eOopEncaps = 3,
         eOopInher = 4,
         eInterfaces = 5,
         eCollection = 6,
         eDelegates = 7,
         eAssemblies = 8,

        }
        static void Main(string[] args)
        {


            var saved = Console.Out;

            using (StreamWriter sw = new StreamWriter(@"E:\out.txt"))
            {
                Console.SetOut(sw);
                Console.WriteLine("DAWID STOGA - WROC");



#if false
                CoreCSPart1.RunExamples(
                CoreCSPart1.Examples.Enviroment
             | CoreCSPart1.Examples.Decision_Constructs
             | CoreCSPart1.Examples.ConsoleClass
             | CoreCSPart1.Examples.ImplicitlyTypes
             | CoreCSPart1.Examples.NarrowingConversion
             | CoreCSPart1.Examples.StringData
             | CoreCSPart1.Examples.SystemDataTypes
             );
#endif

                 Console.SetOut(saved);


                  Multithreaded.RunExamples();
                //  IO.RunIOExamples();
                // AdoNET.RunAdoExamples();



                //CoreCSPart2.Run();
               // OOP_Encaps.Run();
                //OOP_Inher_Poli.Run();
                //Interfaces.Run();
               // Adv.CollRun();
                // Adv.DelRun();
                //Adv.CollRun();
              // Assembliesmod asmMod = new Assembliesmod();
              // asmMod.Run();
                //  LateBinding.Run();
                // FunWithAttributes.Run();

            }
            //  TaskHandling.CallAsyncs();
            // TaskHandling.CallAsyc();

            // Threads.Run();
            //  IO.DirectoryTest();
            //    IO.FileTest();
            //  IO.DirectoryInfo();
            //  IO.FileInfoTest();

            //  IO.FileStreamTest();
            //  IO.StreamWriter();
            //  IO.StreamReader();
            //  IO.StringWriter_ReaderTest();
            //  IO.BinaryReaderWriterTest();
            //  IO.FileWatcher();
            //  SerializeIO.SerializeTest();
            // SerializeIO.SerializeToXML();
            //  AdoNET.dataProviders();
            //AdoNET.ADO_Connected();
            // AdoNET.ADO_Disconnected();
            //   AdoNET.ADO_DataSetBase();

            //  EF_App.EFClient.RunTest();
            //   Console.WriteLine(System.Environment.OSVersion.Platform);


            // Domain.Class1 cl1 = new Domain.Class1();
            //  cl1.Method1();
            Console.Read();
        }


        static class MyStaticClass
        {
            static void Meth()
            {
                Console.WriteLine("Static meth in static Class");
            }

        }
     
}
    

     


    
    
}
