using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.View
{
    internal class QuestionChangedEventArgs : EventArgs
    {
        public QuestionChangedEventArgs(Question? oldQ, Question newQ)
        {
            Old = oldQ;
            New = newQ;
        }
        public Question? Old { get; }
        public Question New { get; }
    }
    internal class CreatePageChangedEventArgs : EventArgs
    {
        public CreatePageChangedEventArgs(CreatePage? oldPage, CreatePage newPage)
        {
            Old = oldPage;
            New = newPage;
        }
        public CreatePage? Old { get; }
        public CreatePage New { get; }
    }
}
