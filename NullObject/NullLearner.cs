namespace NullObject
{
    public class NullLearner : ILearner
    {
        public int Id { get; } = -1;
        public string UserName => "Just Browing";
        public int CoursesCompleted { get; } = 0;
    }
}
