using Git.FileManagerCompsite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.State;

public class ErrorState : BranchState
{
    public ErrorState(FileManager file) : base(file)
    {
    }

    public override void Commit()
    {
        file.ChangeState(new DraftState(file));
    }

    public override void Draft()
    {
        file.ChangeState(new DraftState(file));
    }

    public override void Error()
    {
        throw new NotImplementedException("The Error operation is not implemented in the Error state.");
    }

    public override void Staged()
    {
        throw new NotImplementedException("The Staged operation is not implemented in the Error state");
    }

    public override void UnderReveiw()
    {
        file.ChangeState(new DraftState(file));
    }
}
