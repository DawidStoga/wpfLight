using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Client.BaseLibrary
{
    public partial class IO
    {
        public static void RunIO()
        {
            //  DirectoryTest();
            //  DirectoryInfoTest();
            //  FileTest();
            //  FileInfoTest();
            //   FileStreamTest();
            StreamWriter();

        }

        private static DirectorySecurity GetMySecure()
        {
            var mySecure = new System.Security.AccessControl.DirectorySecurity();
            return mySecure;
        }

        public static void DirectoryTest()
        {
            Console.WriteLine("\n ------------ DIRECTORY CLASS TEST -------------- ");

            //static class
            var dirPathFirst    =    Directory.GetCurrentDirectory() + "\\DirectoryTest";  //Environment.CurrentDirectory
            var dirPathSecond   =    dirPathFirst + "\\DirectoryTest4";
            var dirProject =      "E://Projecty NET";

            /* Create Directory  return DirectoryInfo*/
            Console.WriteLine("CreateDirectory()     retun DirectoryInfo");
            Directory.CreateDirectory(dirPathFirst);
            DirectoryInfo dirInfo =   Directory.CreateDirectory(dirPathSecond/*, GetMySecure()*/);

            Console.WriteLine("Detele()     retun void");
            Directory.Delete(dirPathSecond, recursive: true);
            Directory.Delete(dirPathFirst);

            var Dirs = Directory.EnumerateDirectories(dirProject);
           

            Console.WriteLine("EnumerateDirectories(path)");
            Parallel.ForEach(Dirs, (dir) => Console.WriteLine(dir));

            Console.WriteLine("EnumerateDirectories(path, filter)");
            

            var CustomDirs = Directory.EnumerateDirectories(dirProject, "*" + Console.ReadLine() + "*"); // not regularexpresion
            Parallel.ForEach(CustomDirs, (dir) => Console.WriteLine(dir));

            
            Dirs = Directory.EnumerateFiles(path: dirProject, searchPattern: "*driver*", searchOption: SearchOption.AllDirectories); //todo: check filter
            Parallel.ForEach(Dirs, (dir) => Console.WriteLine(dir));

            Dirs = Directory.EnumerateFileSystemEntries(path: dirProject, searchPattern: "*driver*", searchOption: SearchOption.AllDirectories);  // todo  check behavioir
            Parallel.ForEach(Dirs, (dir) => Console.WriteLine(dir));


            Console.WriteLine("Dir Exists: {0}", 
            Directory.Exists("E:\\sampleDir"));

           /* Directory.CreateDirectory(dirPathSecond, GetMySecure());*/
          //  DirectorySecurity dirSec  = Directory.GetAccessControl(dirPathSecond, AccessControlSections.All);


            var dt = Directory.GetCreationTime(dirPathSecond);
            Console.WriteLine(dt.ToShortDateString());
            Directory.GetCreationTimeUtc(dirPathSecond);
            Console.WriteLine(dt.ToShortDateString());


            Console.WriteLine(".GetDirectories");
            string[] dirsInside = Directory.GetDirectories("G:\\","*");
            Parallel.ForEach(dirsInside, (dir) => Console.WriteLine(dir));


            var Root = Directory.GetDirectoryRoot(Environment.SystemDirectory);
            Console.WriteLine($"GetDirectoryRoot {Root}");

            string[] FilesInside =  Directory.GetFiles("G:\\");
            Parallel.ForEach(FilesInside, (file) => Console.WriteLine(file));

            Console.WriteLine("GetFileSystemEntries");
            Directory.GetFileSystemEntries("G:\\");
            Parallel.ForEach(FilesInside, (file) => Console.WriteLine(file));

            Console.WriteLine("GetLastAccessTime and GetLastWriteTime:");
            dt = Directory.GetLastAccessTime(dirPathSecond);
            Console.WriteLine(dt.ToShortDateString());
            dt = Directory.GetLastWriteTime(dirPathSecond);
            Console.WriteLine(dt.ToShortDateString());

            Console.WriteLine("Drivers:");
            String[] drvs = Directory.GetLogicalDrives();
            Parallel.ForEach(drvs, (drv) => Console.WriteLine(drv));

            Directory.GetParent(dirPathSecond);
            var newDir = Directory.CreateDirectory(Directory.GetCurrentDirectory() + "//NewOne");
            Directory.CreateDirectory(dirPathSecond/*, GetMySecure()*/);
           // Directory.Move(dirPathSecond, newDir.FullName+"Destination"); //todo

            Directory.SetAccessControl(newDir.FullName, directorySecurity: GetMySecure());

            Directory.SetCreationTime(newDir.FullName, new DateTime(1999, 3, 21));
            Directory.SetCurrentDirectory("G:\\");
            //Directory.SetLastAccessTime(path: "xx", new DateTime(yy, zz, xx));
            //Directory.SetLastWriteTime(path: "xx", new DateTime(yy, zz, xx));
           
           
        }
        public static void DirectoryInfoTest()
        {
            Console.WriteLine("\n ------------ DIRECTORYINFO CLASS TEST ++++++++++++ ");

            var path = Directory.GetCurrentDirectory() + "\\DirInfo";
            var path2= Directory.GetCurrentDirectory() + "\\DirInfo2";

            /*Creation */
            DirectoryInfo di = new System.IO.DirectoryInfo(path);  // via ctrol
            di.Create();
            di.CreateSubdirectory("SubDir");

            var dinfo = Directory.CreateDirectory(path + "\\newDir");  //via Directory.CreateDirectory

            FileAttributes fileAttributes = di.Attributes;  //enum
            Console.WriteLine(fileAttributes.ToString());

            //di.CreateObjRef todo: wtf
            Console.WriteLine("Created: {0}", di.CreationTime.ToShortTimeString());
            //di.Delete();
            //di.EnumerateDirectories();
            var dirs = di.EnumerateDirectories(searchPattern: "*", searchOption: SearchOption.AllDirectories);// IEnumerable<DirInfo>
            Parallel.ForEach(dirs, (dir) => { Console.WriteLine(dir); }); 

            var files  = di.EnumerateFiles(searchPattern: "*.txt");   // IEnumerable<FileInfo>
            Parallel.ForEach(files, (file) => { Console.WriteLine(file); });;

           IEnumerable<FileSystemInfo>  filesSystemInfo  =  di.EnumerateFileSystemInfos(searchPattern: "*");
            Console.WriteLine("Exists: {0} ", di.Exists);
            Console.WriteLine("Extension: {0}", di.Extension); 
            Console.WriteLine(di.FullName);
            DirectoryInfo[] dis = di.GetDirectories();
            di.GetFiles(searchOption: SearchOption.AllDirectories, searchPattern: "*.txt");
           // object lts = di.GetLifetimeService(); todo: wtf
           //di.GetObjectData()  wtf
           //di.MoveTo()
           

            
            di.InitializeLifetimeService();  //todo

        }
        public static async void  FileTest()
        {
          var FileString =   Directory.GetCurrentDirectory() + "\\FileTest\\examoleFile.txt";
          var FileText= Directory.GetCurrentDirectory() + "\\FileTest\\exampleFileText.txt";
            var AppendFile   ="E:\\appendFileText.txt";
            var AppendText = Directory.GetCurrentDirectory() + "FileTest\\appendText.txt";
            var decryptFile = Directory.GetCurrentDirectory() + "\\FileTest\\decrypt.txt";


            
            string fileForTestPath = Directory.GetCurrentDirectory() + "\\fileForText.txt";
            string fileToCraterPath = Directory.GetCurrentDirectory() + "\\fileForText.txt";



            File.AppendAllLines(AppendFile, new List<string> { "first Line ", "Second Line ", "Third line" });
            File.AppendAllText(AppendFile, "AppendAllText appends the specified string to file, and then close it. ", encoding: Encoding.Unicode);
            //File.Copy(xx,yy)
           
            /* Creation*/

            using (FileStream fileStream = File.Create(path: FileString, bufferSize: 1024, options: FileOptions.Asynchronous))  //or override
            {

            }

            using (StreamWriter streamWriter = File.CreateText(FileText))    //UTF-8 text
            {

            }

            var fs = File.Create(decryptFile);
            await fs.WriteAsync(new byte[] { 0x30, 0x31, 0x32 }, 0, 3);
            fs.Dispose();

            File.Encrypt(decryptFile);

            File.Decrypt(decryptFile);

           

            using (StreamWriter streamWriter = File.AppendText(AppendText))    //UTF-8   text
            {
                streamWriter.WriteLine("File.AppendText");
            }

            using (FileStream fs3 = File.Open(fileToCraterPath, FileMode.OpenOrCreate))
            {

            }


            using (FileStream fs4 = File.OpenRead(fileToCraterPath))
            {

            }
              

            using (FileStream fs5 = File.OpenWrite(fileToCraterPath))
            {

            }
              


            using (StreamReader sr1 = File.OpenText(fileToCraterPath))
            {

            }
             


            FileAttributes fileAtribute = File.GetAttributes(fileForTestPath);
            Console.WriteLine(fileAtribute.ToString());




           
            byte[] readBytes            = File.ReadAllBytes(fileToCraterPath);
            string[] readStrings        = File.ReadAllLines(fileToCraterPath);
            string readTotalString      = File.ReadAllText(fileToCraterPath);
            List<string> listOfStrings  = File.ReadLines(fileToCraterPath).ToList<string>();

            File.WriteAllBytes(fileToCraterPath, new byte[] { 0x35 });
            File.WriteAllLines(fileToCraterPath,new[]{ "written by WriteAllLines" });
           // File.WriteAllText(fileToCraterPath, "Text");  //overwritten
 
        }

        public static void FileInfoTest()
        {
         

            // Create FileStream, StreamReader, StreamWriter

            FileInfo fi = new FileInfo("E:\\Dirinfo\\fileInfo.txt");
            FileStream fs =  fi.Create();
            Console.WriteLine($@"
            extension      =   {fi.Extension}
            fullName       =   {fi.FullName}
            isReadOnly     =   {fi.IsReadOnly}
            lenght         =   {fi.Length}
            lastAccessTime =   {fi.LastAccessTime}
            ");
            fs.Dispose();
            
            using (StreamWriter sw1 = fi.AppendText())
            {
                sw1.Write("AppendText");
            }
            using (StreamWriter sw2 = fi.CreateText())
            {

            }
              using (StreamReader sr3 = fi.OpenText())
            {

            }

           
            using (FileStream fs2 = fi.Open(FileMode.OpenOrCreate))
            {

            }
            using (FileStream fs3 = fi.OpenRead())
            {

            }
            using (FileStream fs4 = fi.OpenWrite())
            {

            }
        //    FileInfo fileBackup   = fi.Replace("file1", "file2");
        }

        public static async void FileStreamTest()
        {

           var di =  Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\FileTest");
           
            if(!di.Exists) { return; }
            var FilePath = Directory.GetCurrentDirectory() + "\\FileTest\\FileStream.txt";
            var FileCopyPath = Directory.GetCurrentDirectory() + "\\FileTest\\FileStreamCopy.txt";
            using (FileStream fileStream = File.Open(FilePath, FileMode.OpenOrCreate),
                              fileStreamCopy = File.Open(FileCopyPath, FileMode.OpenOrCreate))
            {

                /*Obsolete  or synchronous*/
                //fileStream.BeginRead(...)   readAsync  instead
                //fileStream.EndRead(...)

                //fileStream.BeginWrite(...)  writeAsync instead  
                //fileStream.EndWrite(...) 
                //IntPtr fileHandle =  fileStream.Handle;  //obsolete

                /*Properties*/
                bool bCanRead = fileStream.CanRead;  //Gets a value indicating whether the current stream supports reading.
                bool bCanSeek = fileStream.CanSeek; //Gets a value indicating whether the current stream supports seeking.
               
                bool bCanWrite = fileStream.CanWrite;
                bool bOpenedAsync = fileStream.IsAsync;
                long lenghtInBytes = fileStream.Length;
                string name = fileStream.Name;
                long currentPosition = fileStream.Position;
                if(fileStream.CanTimeout)
                {
                int RdTimeOut = fileStream.ReadTimeout;
                int WrTimeOut = fileStream.WriteTimeout;
                }
               
                SafeFileHandle fileHandle = fileStream.SafeFileHandle;

                /*Methods*/

                //fileStream.CopyTo(fileStreamCopy, bufferSize: 81920); synchornous
                await fileStream.CopyToAsync(fileStreamCopy, bufferSize: 4096).ContinueWith((file) => { Console.WriteLine("...Copying finished"); }); //asynchronous
                //fileStream.CreateObjRef(...)  //todo
                fileStream.Flush(flushToDisk: true);
                await fileStream.FlushAsync();
                fileStream.Lock(position: 0, length: 1024);
                fileStream.Unlock(0, 1024);

                var ReadBuffer = new byte[6] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                var WriteBuffer = new byte[6] { 0x31, 0x32, 0x33, 0x34, 0x35, 0x36 };

                await fileStream.WriteAsync(WriteBuffer, 0, 6);
                fileStream.Read(
                            array: ReadBuffer,
                            offset: 0,
                            count: 3
                            );

                var receivedBytes = await fileStreamCopy.ReadAsync(
                            buffer: ReadBuffer,
                            offset: 3,
                            count: 3
                    );


                int receivedByte = fileStream.ReadByte();

                fileStream.Seek(offset: 0, origin: SeekOrigin.Begin);
                fileStream.Seek(2, SeekOrigin.Begin);  // set the current position;
                fileStream.Seek(0, SeekOrigin.Current);
                fileStream.Seek(-1, SeekOrigin.End);


            }
        }



        public static async void StreamWriter()
        {

            //Creation
            var sw = File.CreateText("E:\\DirInfo\\StreamWriter.txt");
            var sw2 = new StreamWriter(path:"E:\\Dirinfo\\fileInfo.txt",append:true,encoding:Encoding.Default);
            sw2.Dispose();

            using (FileStream fs = new FileStream(path: "E:\\Dirinfo\\fileInfo.txt", mode: FileMode.OpenOrCreate, access: FileAccess.ReadWrite, share: FileShare.ReadWrite))
            {
                using (var sw3 = new StreamWriter(fs))
            {
                    sw3.WriteLine("Save data to stream");
            }

            }
           

            

            Stream swBase = sw.BaseStream;  //Gets the underlying stream that interfaces with a backing store.
       

            Console.WriteLine($@"
                          autoFlush      {sw.AutoFlush} 
                          encoding       {sw.Encoding}  
                          formatProvider {sw.FormatProvider} 
                          new line term  {sw.NewLine}");  //defsult UTF

            
            //sw.Flush();
            await sw.FlushAsync();
            sw.Write("string was written");
            sw.Write(10);
            sw.Write(true);
            sw.Write(new char[] { 'a', 'b', 'x' });
            await sw.WriteAsync(new char[] { 'T', 'h', 'i', 's', ' ', 'i', 's' },index:2, count:3);
            sw.WriteLine("Aa");
            sw.WriteLine("Bb");
            await sw.WriteLineAsync("Cc");

            sw.Dispose();
          



        
        }

      public  static async  void StreamReader()
        {
            Thread.Sleep(200 );

            
            char[] myBuffer = new char[60];
            StreamReader sr = File.OpenText("D:\\DirInfo\\StreamWriter.txt");
            Stream stream = sr.BaseStream;
            Encoding enc = sr.CurrentEncoding;
            sr.DiscardBufferedData(); // cklear rthe interna buffer
            bool bIsAtTheEnd = sr.EndOfStream;
           int nextChar =  sr.Peek(); // return the next character but not consuming 
             nextChar  = sr.Read(); // return next char and advances index
            int iCharCnt = sr.Read(myBuffer, 0,20);
           iCharCnt = await sr.ReadAsync(myBuffer, 0, 10);
           sr.ReadBlock(myBuffer, 0,20);
            await sr.ReadBlockAsync(myBuffer, 0, 20);
            string line = sr.ReadLine();
            line =   await sr.ReadLineAsync();
            stream.Position = 0;
          string  all =   sr.ReadToEnd();
              stream.Position = 0;
            
            Console.WriteLine(await sr.ReadToEndAsync());

        }

        public static async void StringWriter_ReaderTest()
        {
            StringBuilder stringToRead_Write = new StringBuilder();


            using (StringWriter sw = new StringWriter())
            {
                sw.Write(" String Writer Reader ");
                await sw.WriteLineAsync();
                sw.Write("Stoga");
                stringToRead_Write =  sw.GetStringBuilder();
               
               
            }
            
            stringToRead_Write.AppendLine("Characters in 1st line to read");
            stringToRead_Write.AppendLine("and 2nd line");
            stringToRead_Write.AppendLine("and the end");
            using (StringReader sr = new StringReader(stringToRead_Write.ToString()))
            {
                string readText = await sr.ReadToEndAsync();
                Console.WriteLine(readText);
            }


        }


        public static void BinaryReaderWriterTest()
        {
            StreamReader sr = File.OpenText("D:\\DirInfo\\StreamWriter.txt");
         

            BinaryWriter bw = new BinaryWriter(sr.BaseStream);
            bw.Write("BINARY WRITER");
            bw.Seek(6, SeekOrigin.Begin);
            bw.Write("IO ");
            bw.Close();

            BinaryReader br = new BinaryReader(sr.BaseStream);
            Console.WriteLine(  br.ToString());

        }
        public static void FileWatcher()
        {
            FileSystemWatcher fsw = new FileSystemWatcher("D:\\DirInfo","*.txt");
          
            fsw.Changed += Fsw_Changed;
            fsw.NotifyFilter = NotifyFilters.LastWrite;
            fsw.IncludeSubdirectories = true;
            fsw.Created += Fsw_Created;  
            fsw.EnableRaisingEvents = true;
            File.Create("D:\\DirInfo\\Watcwh.txt");

        }

        private static void Fsw_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Something was created");
        }

        private static void Fsw_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Something was changed");
        }

        public static void StreamBase()
        {
            MemoryStream ms = new MemoryStream();
            bool result;

            FileInfo fi = new FileInfo("D:\\Dirinfo\\fileInfo.txt");

            FileStream fs = File.Create("D:\\DirInfo\\plik.txt");
            StreamWriter sw = fi.CreateText();
            StreamReader sr = fi.OpenText();
           result =  fs.CanRead;
            result= fs.CanSeek;
            result= fs.CanWrite;
            fs.CopyTo(ms);
           // fs.CopyToAsync()

            ms.Close();

            fs.Close();

        }

    }
}
