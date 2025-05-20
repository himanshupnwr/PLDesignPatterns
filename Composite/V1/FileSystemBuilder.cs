using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.V1
{
    public class FileSystemBuilder
    {
        private Directory currentDirectory;
        public Directory Root { get; }

        public FileSystemBuilder(string rootDirectory, int size)
        {
            this.Root = new Directory(rootDirectory, size);
            this.currentDirectory = this.Root;
        }

        public Directory AddDirectory(string name, int size)
        {
            var dir = new Directory(name, size);
            this.currentDirectory.Add(dir);
            this.currentDirectory = dir;
            return dir;
        }

        public File AddFile(string name, int size)
        {
            var file = new File(name, size); 
            this.currentDirectory.Add(file);
            return file;
        }

        public Directory SetCurrentDirectory(string dirname)
        {
            var dirStack = new Stack<Directory>();
            dirStack.Push(this.Root);
            while (dirStack.Count > 0) 
            { 
                var current  = dirStack.Pop(); 
                if(current.Name == dirname)
                {
                    this.currentDirectory = current;
                    return current;
                }
                foreach (var item in current._fileSystemItems.OfType<Directory>())
                {
                    dirStack.Push(item);
                }
            }
            throw new InvalidOperationException($"Directory name {dirname} not found");
        }
    }
}
