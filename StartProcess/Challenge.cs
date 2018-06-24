namespace StartProcess
{
    public class Challenge
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProblemStatement { get; set; }
        public string InputFormat { get; set; }
        public string Constraint { get; set; }
        public string OutputFormat { get; set; }
        public string Tags { get; set; }
        public Difficulty Difficulty { get; set; }
    }

    public enum Difficulty
    {
        Easy, 
        Medium, 
        Hard, 
        Advanced, 
        Expert
    }
    
}
