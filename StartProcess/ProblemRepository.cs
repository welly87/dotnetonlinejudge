using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StartProcess
{
    public class ProblemRepository
    {
        public Problem Get(int problemId)
        {
            var tcFolder = $@"E:\ojworkspace\testcases\{problemId}";
            
            var tcInput = Path.Combine(tcFolder, "input");
            var inputs = Directory.EnumerateFiles(tcInput).ToList();
            
            var tcOutput = Path.Combine(tcFolder, "output");
            var outputs = Directory.EnumerateFiles(tcOutput).ToList();
            
            var testCases = new List<TestCase>();

            for (int i = 0; i < inputs.Count; i++)
            {
                testCases.Add(new TestCase { Input = File.ReadAllText(inputs[i]), Output = File.ReadAllText(outputs[i])});
            }

            return new Problem
            {
                MemoryLimit = 1000,
                RuntimeLimit = 1,
                TestCases = testCases
            };
        }
    }
}