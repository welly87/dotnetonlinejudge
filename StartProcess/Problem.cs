using System.Collections.Generic;

namespace StartProcess
{
    public class Problem
    {
        public int MemoryLimit { get; set; }

        public int RuntimeLimit { get; set; }

        public List<TestCase> TestCases { get; set; }
    }
}