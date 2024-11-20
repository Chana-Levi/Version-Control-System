﻿using Git.FileManagerCompsite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.State;

public class DraftState : BranchState
{
    public DraftState(FileManager file) : base(file)
    {
    }
    public override void Commit()
    {
        file.ChangeState(new CommittedState(file));
    }
    public override void Draft()
    {
        throw new NotImplementedException("The Draft operation is not implemented in the Draft state");
    }
    public override void Error()
    {
        throw new NotImplementedException("The Error operation is not implemented in the Draft state.");
    }
    public override void Staged()
    {
        throw new NotImplementedException("The Staged operation is not implemented in the Draft state");
    }
    public override void UnderReveiw()
    {
        throw new NotImplementedException("The Under Review operation is not implemented in the Draft stat");
    }
}
