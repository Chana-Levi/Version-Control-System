using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Fiyweight
{
    internal class FileFactory 
    {
        static FileFactory fileFactory;
        public Dictionary<string, Git.FileManagerCompsite.File> files;
        public static object locker;
        static FileFactory()
        {
            locker = new object();
        }
        private FileFactory()
        {
            files = new();
        }
        //SINGLETONE
        public static FileFactory GetInstance()
        {
            if (fileFactory == null)
            {
                lock (locker)
                {
                    if(fileFactory == null)
                    {
                        fileFactory = new FileFactory();
                    }

                }
            }
            return fileFactory;
        }
        public Git.FileManagerCompsite.File GetFile(string name,string branchName, double size, string status)
        {
            string fileKey = $"{name}_{branchName}";
            if(files.ContainsKey(fileKey))
            {
                return files[fileKey];
            }
            Git.FileManagerCompsite.File file = new(name, size, status);
            files.Add(fileKey, file);
            return file;
        }
    }
}
