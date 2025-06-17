namespace NullObject
{
    public class LearnerView
    {
        private readonly ILearner _learner;

        public LearnerView(ILearner learner)
        {
            _learner = learner;
        }

        public void RenderView()
        {
            Console.WriteLine("UserName" + _learner.UserName);
            Console.WriteLine("CoursesCompleted" + _learner.CoursesCompleted);
        }
    }
}
