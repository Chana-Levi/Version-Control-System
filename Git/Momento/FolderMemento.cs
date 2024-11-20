using Git.FileManagerCompsite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Momento
{
    public class FolderMemento:FileManagerMemento
    {
        public List<FileManager> Content { get; }
        public FolderMemento(List<FileManager> content)
        {
            Content = content;
        }
    }
}
