using Git.FileManagerCompsite;
using Git.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.State
{
    public abstract class BranchState
    {

        protected FileManagerCompsite.FileManager file { get; }
        public string status { get; set; }  

        public BranchState(FileManagerCompsite.FileManager file, string status)
        {
           this.file = file;
            this.status = status;
        }
        public BranchState(FileManagerCompsite.FileManager file)
        {
            this.file = file;
        }
        public void changeState(BranchState state) { 
            this.status = state.status;
        }
        public void Merge() { }
        public void UndoTheCommit() { }
        public void RequestReview() { }
        public void UnderReview() { }
        public abstract void Commit();
        public abstract void Staged();
        public abstract void UnderReveiw();
        public abstract void Error();
        public abstract void Draft();

        
    }
}




