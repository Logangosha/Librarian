using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian
{
    public class File : StorageItem
    {
        // Properties
        public string FileType { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime LastAccessed { get; set; }
        // Constructors
        public File(string name, DateTime createdAt, long size, string location, string fileType, DateTime lastModified, DateTime lastAccessed) : base(name, createdAt, size, location)
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("File() Called");
            this.FileType = fileType;
            this.LastModified = lastModified;
            this.LastAccessed = lastAccessed;
        }
        //Functions
        public override void Delete()
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("Delete() Called");
            base.Delete();
        }
    }
}
