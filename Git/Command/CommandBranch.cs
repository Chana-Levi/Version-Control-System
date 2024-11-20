
using Git.FileManagerCompsite;

namespace Git.Command;

public abstract class CommandBranch
{
    protected FileManager fileManager;

    public CommandBranch(FileManager fileManager)
    {
        this.fileManager = fileManager;
    }

    public abstract void Execute();
}
