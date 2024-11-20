using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Momento
{
    public class FileMemento: FileManagerMemento
    {
        public string Content { get; }
        public FileMemento(string content)
        {
            Content = content;
        }
        
    }
}
