using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian
{
    public class Folder : StorageItem
    {
        // Properties
        public List<StorageItem> Contents { get; set; }
        public int SubfolderCount { get; set; }
        public int FileCount { get; set; }
        // Constructors
        public Folder(string name, DateTime createdAt, long size, string location, List<StorageItem> contents, int subfolderCount, int fileCount) : base(name, createdAt, size, location)
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("Folder() Called");
            this.Contents = contents;
            this.SubfolderCount = subfolderCount;
            this.FileCount = fileCount;
        }
        //Functions
        public void AddItem(StorageItem item)
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("AddItem() Called");
            this.Contents.Add(item);
        }
        public void RemoveItem(StorageItem item)
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("RemoveItem() Called");
            this.Contents.Remove(item);
        }
        public override void Delete()
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("Delete() Called");
            base.Delete();
        }
        
    }
}
