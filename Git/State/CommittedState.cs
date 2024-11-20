using Git.FileManagerCompsite;


namespace Git.State
{
    public class CommittedState : BranchState
    {
        public CommittedState(FileManager file):base(file)
        {

        }
        public CommittedState(FileManager file, string status) : base(file, status)
        {
        }

        public override void Commit()
        {
            //פעולת Commit אינה במצב Committed
            throw new NotImplementedException("The Commit operation is not implemented in the Committed state");
        }

        public override void Draft()
        {
            file.ChangeState(new DraftState(file));
        }

        public override void Error()
        {
            file.ChangeState(new ErrorState(file));

        }
        public override void Staged()
        {
            throw new NotImplementedException("The Staged operation is not implemented in the Committed state.");
        }

        public override void UnderReveiw()
        {
            throw new NotImplementedException("The Under Review operation is not implemented in the Committed state.");
        }

    }
}
