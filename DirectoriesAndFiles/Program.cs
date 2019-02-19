using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*
You will be creating an application that will help you get familiar with using internet resources and solving
what seems to be a complex problem.  You will create a console application and then prompt the user to enter a directory path
(e.g. C:/temp).  You will need to make sure that it exists, if it does exist then we want to output all of the files in the directory
(including extension) but not the full path (e.g.  If there is a file named exam1.docx in c:\ temp, you would display exam1.docx and
not c:\temp\exam1.docs)

Useful links:
https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.exists?view=netframework-4.7.2
https://docs.microsoft.com/en-us/dotnet/api/system.io.directoryinfo.getfiles?view=netframework-4.7
*/

namespace DirectoriesAndFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter in a directory path (e.g. C:/temp).");
            Console.WriteLine();
            string filepath = Console.ReadLine();
            DirectoryInfo DIfilepath = new DirectoryInfo(filepath);
            Console.WriteLine();
            if (File.Exists(filepath))
            {
                
                foreach (var file in DIfilepath.GetFiles())
                {
                    Console.WriteLine(file.Name);
                }
            }
            else if (Directory.Exists(filepath))
            {
              
                foreach (var file in DIfilepath.GetFiles())
                {
                    Console.WriteLine(file.Name);
                }
            }
            else
            {
                Console.WriteLine($"{filepath} is not a valid directory or filepath.");
            }
            Console.ReadKey();
        }
    }
}
