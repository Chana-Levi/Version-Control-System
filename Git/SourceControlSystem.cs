using Git.Command;

namespace Git;

public class SourceControlSystem
{
    Queue<CommandBranch> commandQueue;
    public List<Repository> repositorys;
    public SourceControlSystem()
    {
        commandQueue = new Queue<CommandBranch>();
    }
    public void PlacesystemItemRequest(CommandBranch command)
    {
        commandQueue.Enqueue(command);
    }
    //הפעולה עוברת על התור ולוקחת את הפקודה ומבצעת אותה
    public void DoJob()
    {
        while (commandQueue.Count > 0)
        {
            var commandToDo = commandQueue.Dequeue();
            commandToDo.Execute();

        }
    }
}



