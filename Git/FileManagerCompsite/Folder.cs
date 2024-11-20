
using Git.Momento;
using System.Xml.Linq;

namespace Git.FileManagerCompsite;

public class Folder : FileManager
{
    public List<FileManager> folders { get; private set; }
    public Folder(string name, double size, string status) : base(name, size, status)
    {
        folders = new List<FileManager>();
    }
    public void Add(FileManager f)
    {
        Push(new FolderMemento(folders));
        folders.Add(f);
        Size += f.Size;
    }
    public bool Remove(FileManager f)
    {
        Push(new FolderMemento(folders));
        FileManager file = folders.Find(f =>  f.Name == f.Name);
        if (file != null)
        {
            folders.Remove(file);
            Size -= file.Size;
            return true;
        }
        return false;
    }
    public override string ShowDetails(int depth)
    {
        string indent = base.ShowDetails(depth);
        string s = $"{indent}{nameof(Folder)}- name: {Name}, size: {Size}KB";
        foreach (var item in folders)
        {
            s += "\n";
            s += item.ShowDetails(depth + 1);
        }
        return s;
    }
    public void Clear()
    {
        folders.Clear();
    }
}
