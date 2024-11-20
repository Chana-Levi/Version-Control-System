using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git;

public class Repository
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Version { get; set; }
    public List<Branch> Branches { get; set; }
    public Repository(string name, string description, string version)
    {
        Name = name;
        Description = description;
        Version = version;
        Branches = new List<Branch>();
    }

}
