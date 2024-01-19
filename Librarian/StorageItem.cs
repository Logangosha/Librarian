using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian
{
    public class StorageItem
    {
        // Properties
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public long Size { get; set; }
        public string Location { get; set; }
        // Constructors
        public StorageItem(string name, DateTime createdAt, long size, string location)
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("StorageItem() Called");
            this.Name = name;
            this.CreatedAt = createdAt;
            this.Size = size;
            this.Location = location;
        }
        // Functions
        public virtual void Delete()
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("Delete() Called");
        }

        public void Move(string newLocation)
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("Move() Called");
            this.Location = newLocation;
        }

        public void Rename(string newName)
        {
            if (GlobalVariables.IsDebuging)
                Console.WriteLine("Rename() Called");
            this.Name = newName;
        }
    }
}
