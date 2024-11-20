using Git;
using Git.FileManagerCompsite;
using Git.State;

Console.WriteLine("Chani_Levi");
SourceControlSystem sourceControlSystem = new SourceControlSystem();
#region user
//User
User schoolgirls = new User("Chani", "c0533100968@gmail.com", "1122", true);
User schoolgirls1 = new User("Sari", "saraduvdev@gmail.com", "2233", false);
User schoolgirls2 = new User("Elisheva", "Pinches77@gmail.com", "3344", true);
#endregion
#region reposetory
//Repository
Repository git = new Repository("git project", "Building GIT", "24");
Repository angular = new Repository("angular project", "Building a recipe book", "24");
Repository c_server_sql = new Repository("c_server_sql project", "Building a website", "4.17");
#endregion
//#region branch
//Branch branch1 = new Branch("Opening a project", angular);
//Branch branch2 = new Branch("project", git);
//Branch branch3 = new Branch("start pyton project", c_server_sql);
//#endregion
