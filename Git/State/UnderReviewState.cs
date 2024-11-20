using Git.FileManagerCompsite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.State
{
    public class UnderReviewState : BranchState
    {
        public UnderReviewState(FileManager file) : base(file)
        {
        }

        public override void Commit()
        {
            throw new NotImplementedException("The Commit operation is not implemented in the Under Review state.");
        }
        public override void Draft()
        {
            throw new NotImplementedException("The Error operation is not implemented in the Under Review state.");
        }

        public override void Error()
        {
            throw new NotImplementedException("The Error operation is not implemented in the Under Review state."); 
        }
        public override void Staged()
        {
            throw new NotImplementedException("The Staged operation is not implemented in the Under Review state.");
        }

        public override void UnderReveiw()
        {
            throw new NotImplementedException("The Under Review operation is not implemented in the Under Review state.");
        }
    }
}
