using System;

namespace StartProcess
{
    public class GradeNewSubmission
    {
        public Guid Id { get; set; }
        public string SourceCode { get; set; }
        public int ProblemId { get; internal set; }
    }
}