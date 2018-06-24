namespace StartProcess
{
    public class ProcessResult
    {
        public bool Completed { get; set; }
        public int? ExitCode { get; set; }
        public string Output { get; set; }
        public string Error { get; set; }
    }
}
