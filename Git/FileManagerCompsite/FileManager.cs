using Git.Momento;
using Git.State;


namespace Git.FileManagerCompsite;

public abstract class FileManager
{
    public string Name { get; set; }
    public double Size { get; set; }
    public string Status { get; set; }
    protected BranchState state { get; set; }
    public BranchState current { get; set; }
    public Branch FatherBranch { get; set; }
    public List<User> UsersReview { get; set; }
    public Stack<FileManagerMemento> History { get; set; }
    protected FileManager(string name, double size, string status)
    {
        Name = name;
        Size = size;
        Status = status;
        History = new Stack<FileManagerMemento>();
    }
    public FileManagerMemento Pop()
    {
        return History.Pop();
    }
    public void Push(FileManagerMemento memento)
    {
        History.Push(memento);
    }
    public void Commit(string BranchName)
    {
        //קשור לSTATE שלא יכולות לעשות לעשות כל פונקציה לכן בודקים אם לא הוא נופל
        state.Commit();
        if (current.GetType() == typeof(DraftState))
        {
            string NameOfTheCommit = Console.ReadLine();
            //מצביע
            FatherBranch.Commits.Add(NameOfTheCommit);
            Console.WriteLine("go to commit state");
            current.UnderReveiw();
        }
        else
        {
            //רק מהטיוטה אתה יכול ללכת ל-commit state
            Console.WriteLine("only from draft you can go to commit state");
            current.Error();
        }
    }
    public bool Merge()
    {
        
        state.Merge();
        if (current.GetType() == typeof(CommittedState))
        {
            if (UsersReview.Count == 0)
            {
                //לא הוקצו סוקרים לקובץ זה. לא ניתן למזג
                Console.WriteLine("No reviewers assigned for this file. Unable to merge.");
                return false;
            }
            bool allApproved = true;
            foreach (var user in UsersReview)
            {
                if (!user.Approved)
                {
                    allApproved = false;
                    break;
                }
            }
            if (allApproved)
            {
                //כל הסורקים אישרו. ממזג קובץ...
                Console.WriteLine("All reviewers approved. Merging file...");
                // Perform merging logic here
                Console.WriteLine("File merged successfully.");
                return true;
            }
            else
            {
                //לא כל הסוקרים אישרו. לא ניתן למזג
                Console.WriteLine("Not all reviewers approved. Unable to merge.");
                return false;
            }
        }
        else
        {
            //הקובץ חייב להיות במצב commit כדי להתמזג
            Console.WriteLine("File must be in commit state to merge.");
            return false;
        }
    }
    //זה קשור לOBSERVER הוא מעורר שמי שיכול לאשר
    public void RequestReview(User reviewer)
    {
        state.Commit();
        // בדיקה אם המצב הנוכחי הוא DraftState
        if (current.GetType() == typeof(DraftState))
        {
            // הוספת הבודק לרשימת המשתמשים לצורך ביקורת
            UsersReview.Add(reviewer);
            //מבקש ביקורת מאת
            Console.WriteLine($"Requesting a review from {reviewer.UserName}");

            // שינוי המצב ל-UnderReviewState
            current.UnderReview();
        }
        else
        {
            //ביקורת יכולה להיבקש רק מ - DraftState
            Console.WriteLine("A review can only be requested from DraftState.");
            current.Error();
        }
    }
    public void Undo()
    {
        state.Commit();
        // בדיקה שהמצב הנוכחי הוא UnderReviewState
        if (current.GetType() == typeof(UnderReviewState))
        {
            // ביטול ההתחייבות הפעולות הנדרשות לביטול ההתחייבות
            // דוגמה: ביטול שליחת הנתונים לביקורת וחזרה למצב הקודם
            //ההתחייבות בוטלה בהצלחה
            Console.WriteLine("The commitment was successfully cancelled");

            // שינוי המצב ל- DraftState
            current.Draft();
        }
        else
        {
            // אין אפשרות לבצע ביטול התחייבות כרגע.
            Console.WriteLine("It is not possible to cancel a commitment at this time.");
            current.Error();
        }
    }
    public void FileMenager(string BranchName, double Size, BranchState State) { }
    public void ChangeState(BranchState State)
    {
        current = State;
    }
    //public FileManagerMemento SaveMemento() { }
    public void NotifyReviewer()
    {

    }
    //סוקר את הקובץ
    public void RemoveReviewer(User user)
    {
        UsersReview.Remove(user);
    }
    public void AddReviewer(User user)
    {
        UsersReview.Add(user);
    }
    public virtual string ShowDetails(int depth)
    {
        string indent = "";
        for (int i = 0; i < depth; i++, indent += "\t") ;
        return indent;
    }
}
