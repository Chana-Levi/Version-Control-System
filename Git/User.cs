
using Git.Observer;

namespace Git;

public class User : IReviewer
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Approved { get; internal set; }

    public User(string userName, string email, string password, bool approved)
    {
        UserName = userName;
        Email = email;
        Password = password;
    }

    public void Update()
    {
        Console.WriteLine($"Hi {UserName}: File is waiting for approval");
    }
}
