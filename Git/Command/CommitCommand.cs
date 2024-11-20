

using Git.FileManagerCompsite;

namespace Git.Command;

public class CommitCommand : CommandBranch
{
    string branchName;
    public CommitCommand(FileManager fileManager, string branchName) : base(fileManager)
    {
        this.branchName = branchName;
    }

    public override void Execute()
    {
        fileManager.Commit(branchName);
    }
}
