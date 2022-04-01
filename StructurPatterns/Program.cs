using System;

namespace StructurPatterns.Compozite
{
    class Program
    {
        public static void Main()
        {
            Component rootFolder = new Folder("Root");

            Component myFile = new File("MyFile.txt");

            Folder docFolder = new Folder("Mydoc");

            rootFolder.Add(myFile);
            rootFolder.Add(docFolder);
            rootFolder.Display();

        }
    }
   
}