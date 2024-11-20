using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Git.FileManagerCompsite
{
    public class File : FileManager
    {
        public string Content { get; set; }

        public File(string name, double size, string status) : base(name, size, status)
        {
        }
        public override string ShowDetails(int depth)
=> $"{base.ShowDetails(depth)}{nameof(File)}- name: {Name}, size: {Size}KB";
    }
}
