using Git.FileManagerCompsite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Command
{
    public class UndoTheCommit : CommandBranch
    {
        public UndoTheCommit(FileManager fileManager) : base(fileManager)
        {
        }
        public override void Execute()
        {
            fileManager.Undo();
        }
    }
}
