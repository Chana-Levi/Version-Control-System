using Git.State;
using Git.FileManagerCompsite;
using Git.Fiyweight;

namespace Git;

public class Branch
{
   
    #region member
    public string BranchName { get; set; }
    BranchState state { get; set; }
    public List<string> Commits { get; set; }
   //FileManager FileManager { get; set; }
    FileFactory FileFactory { get; set; }
    public List<Branch> Branches { get; set; }
    public List<FileManager> FileManager { get; set; }
    
    #endregion
    #region func
    public Branch(string branchName, List<FileManager> fileManager, BranchState state)
    {
        BranchName = branchName;
        FileManager = fileManager;
        this.state = state;
        Branches = new List<Branch>();
        Commits = new List<string>();
        FileFactory = FileFactory.GetInstance();
    }

    public bool RemoveBranch(Repository repository)
    {
        Console.WriteLine("Are you sure you want to delete?");
        if (Console.ReadLine().Equals("y"))
        {
            repository.Branches.Remove(this);
            Console.WriteLine($"{this.BranchName} deleted.");
            return true;
        }
        return false;
    }
    //מוסיף פריט לפרטי מערכת
    public string AddFile(FileManager file)
    {
        FileManager.Add(file);
        return $"The file {file.Name} has been added successfully.";
    }
    //מחזירה את המצב הנוכחי
    public BranchState CurrentState(Branch branch)
    {
        BranchState state = branch.state;
        return state;
    }
    public void ChangeFile(string content, string name, double size, string status)
    {
        Git.FileManagerCompsite.File file = FileFactory.GetFile(name, BranchName, size, status);
        file.Content = content;
    }
    //prototypeבבוקר אחרי ההפסקה של 5 דקות לבדוק האם זה טוב לעשות את זה פו ו
    public string CreateBranch(string BranchName)
    {
        Branches.Add((Branch)Clone());
        Branches[Branches.Count - 1].BranchName = BranchName;
        return $"the branch {BranchName} had created successfully.";
    }
    public object Clone()
    {
        return new Branch(BranchName, FileManager, state);
    }

    #endregion
}
