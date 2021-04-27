using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;

namespace ScriptCopyFilesFromOneDirectoryToAnother
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                string rootPath = @"C:\Users\jonathan.fidalgopere\Desktop\SBE\SBE Directory Test"; // show folders only

                string[] dirs = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

                Console.WriteLine("Show folders in C:\\SBE\\SBE Directory Test");
                Console.WriteLine();

                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                }

                Console.WriteLine("Show files in C:\\SBE\\SBE Directory Test");
                Console.WriteLine();

                var files = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories); //Show files only ("*.*" --> search pattern) // *.dwg*||*.ifc*||*.txt*||*.txt*||*.xlsx*

                foreach (string file in files)
                {
                    Console.WriteLine(file);
                    //Console.WriteLine(Path.GetFileName(file));
                    var info = new FileInfo(file);
                    Console.WriteLine($"{info.LastWriteTimeUtc} - {info.Length / 1024} bytes"); //Convert bytes to kilobytes bytes/1024 = kilobytes         
                }

                Console.ReadLine();

                string[] copyFiles = Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);
                string destinationFolder = @"C:\Users\jonathan.fidalgopere\Desktop\NewestFiles\";

                foreach (string file in copyFiles)
                {
                    File.Copy(file, $"{destinationFolder}{Path.GetFileName(file) }", false);  //False boolean will only overwrite if destination file is older than target file       
                }

                Console.ReadLine();

            }
        }
    }
}
