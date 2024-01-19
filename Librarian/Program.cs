using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Librarian 
{
    public static class GlobalVariables
    {
        public static bool IsDebuging = true;

    }

    class Program
    {
        static void Main()
        {
            Librarian librarian = new Librarian();
            
            // dispaly root directory
            librarian.DisplayRootDirectoryContents();
            
            // clear Results directory
            librarian.ClearResultsDirectoryContents(librarian.ResultsDirectory);

            // copy Root directory to Results directory
            librarian.CopyPasteRootDirectoryContentsIntoResultsDirectory();

            // organise results directory 
            librarian.OrganizeResultsDirectory();
            Console.ReadLine();
        }
    }
}