using Git.FileManagerCompsite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Command;

public class RequestReviewCommand : CommandBranch
{
    User reviewer;
    public RequestReviewCommand(User reviewer, FileManager fileManager) : base(fileManager)
    {
        this.reviewer = reviewer;
    }
    public override void Execute()
    {
        fileManager.RequestReview(reviewer);
    }
}
