using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian
{
    public class Librarian
    {
        // Properties
        public string RootDirectory { get; set; }
        public string ResultsDirectory { get; set; }
        public List<StorageItem> RootDirectoryContents { get; set; }
        public List<StorageItem> ResultsDirectoryContents { get; set; }
        // Constructors
        public Librarian()
        {
            this.RootDirectory = GetRootDirectory();
            this.ResultsDirectory = GetResultsDirectory();
            this.RootDirectoryContents = GetContentsFromRootDirectory();
            this.ResultsDirectoryContents = new List<StorageItem>();
            this.ResultsDirectoryContents.AddRange(this.RootDirectoryContents);

            if (GlobalVariables.IsDebuging)
            Console.WriteLine("Librarian Created");
        }
        // Functions
        public string GetRootDirectory()
        {
            // path to downloads folder Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string rootDirectory = "C:\\Users\\Logan\\OneDrive\\Documents\\Librarian\\Librarian\\Librarian\\root\\";
            return rootDirectory;
        }
        public string GetResultsDirectory()
        {
            string resultsDirectory = "C:\\Users\\Logan\\OneDrive\\Documents\\Librarian\\Librarian\\Librarian\\results\\";
            return resultsDirectory;
        }
        public List<StorageItem> GetContentsFromRootDirectory()
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("GetRootDirectoryContentsFromRoot() Called");
            List<StorageItem> storageItems = new List<StorageItem>();
            if (Directory.Exists(this.RootDirectory))
            {
                if (GlobalVariables.IsDebuging)
                    Console.WriteLine("Root Directory Exists");
                storageItems = GetFoldersFromRootDirectory(storageItems);
                storageItems = GetFilesFromRootDirectory(storageItems);
                return storageItems;
            }
            else
            {
                if (GlobalVariables.IsDebuging)
                    Console.WriteLine("Root Directory Does Not Exist");
                return storageItems;
            }
        }
        public List<StorageItem> GetFoldersFromRootDirectory(List<StorageItem> storageItems)
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("GetFoldersFromRoot() Called");
            string[] folders = Directory.GetDirectories(this.RootDirectory);
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("folders found " +folders.Length);
            foreach (string folder in folders)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folder);
                Folder newFolder = new Folder(directoryInfo.Name, directoryInfo.CreationTime, 0, directoryInfo.FullName, new List<StorageItem>(), 0, 0);
                storageItems.Add(newFolder);
            }
            return storageItems;
        }
        public List<StorageItem> GetFilesFromRootDirectory(List<StorageItem> storageItems)
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("GetFilesFromRoot() Called");
            string[] files = Directory.GetFiles(this.RootDirectory);
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("files fount " + files.Length);
                foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                File newFile = new File(fileInfo.Name, fileInfo.CreationTime, fileInfo.Length, fileInfo.FullName, fileInfo.Extension, fileInfo.LastWriteTime, fileInfo.LastAccessTime);
                storageItems.Add(newFile);
            }
            return storageItems;
        }
        public void OrganizeResultsDirectory()
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("OrganizeResultsDirectory() Called");
            string itemNames = "";
            if (GlobalVariables.IsDebuging)
                Console.WriteLine(ResultsDirectoryContents.Count());
            foreach (StorageItem item in ResultsDirectoryContents)
            {
                itemNames += item.Name + ","; 
            }
            if (GlobalVariables.IsDebuging)
                Console.WriteLine(itemNames);
        }
        public void DisplayRootDirectoryContents()
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("DisplayRootDirectoryContents() Called");
            Console.WriteLine("\nRootDirectoryContents:");
            foreach (StorageItem item in RootDirectoryContents)
            {
                    Console.WriteLine(item.Name);
            }
            Console.WriteLine();
        }
        public void ClearResultsDirectoryContents(string folderPath)
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("ClearResultsDirectoryContents() called");

            foreach (string file in Directory.GetFiles(folderPath))
            {
                System.IO.File.Delete(file);
                if (GlobalVariables.IsDebuging)
                    Console.WriteLine("file deleted: " + file);
            }
            foreach (string subFolder in Directory.GetDirectories(folderPath))
            {
                ClearResultsDirectoryContents(subFolder);
                Directory.Delete(subFolder);
                if (GlobalVariables.IsDebuging)
                    Console.WriteLine("subFolder deleted: " + subFolder);
            }
        }
        public void CopyPasteRootDirectoryContentsIntoResultsDirectory() 
        {
            if(GlobalVariables.IsDebuging)
                Console.WriteLine("CopyPasteRootDirectoryContentsIntoResultsDirectory() called");

            if (GlobalVariables.IsDebuging)
                Console.WriteLine("Unique Directory Paths:");
            foreach (string dirPath in Directory.GetDirectories(RootDirectory, "*", SearchOption.AllDirectories))
            {   
                if(GlobalVariables.IsDebuging)
                    Console.WriteLine("Directory Path: " + dirPath);
                Directory.CreateDirectory(Path.Combine(ResultsDirectory, dirPath.Substring(RootDirectory.Length)));
            }

            if (GlobalVariables.IsDebuging)
                Console.WriteLine("Unique File Paths:");
            foreach (string filePath in Directory.GetFiles(RootDirectory, "*", SearchOption.AllDirectories))
            {
                if (GlobalVariables.IsDebuging)
                    Console.WriteLine("File Path: " + filePath);
                System.IO.File.Copy(filePath, Path.Combine(ResultsDirectory, filePath.Substring(RootDirectory.Length)), true);
            }
        }
    }
}
