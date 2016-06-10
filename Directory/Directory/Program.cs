using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryMain
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowWindowsDirectoryInfo();
            Console.ReadLine();
        }

        static void ShowWindowsDirectoryInfo()
        {
            // Dump directory information.
            DirectoryInfo dir = new DirectoryInfo(@"E:\Practice");
            FileInfo[] fileInfo = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            int count = fileInfo.Length;
            Console.WriteLine("Count: {0}", count);
            Console.WriteLine("***** Directory Info *****");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
            Console.WriteLine("**************************\n");

            string[] logicalFiles = Directory.GetLogicalDrives();
            foreach (var item in logicalFiles)
            {
                Console.WriteLine(item);
            }

        }
    }
}
