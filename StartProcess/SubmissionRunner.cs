using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace StartProcess
{
    public class SubmissionRunner
    {
        private ProblemRepository repository;

        public SubmissionRunner(ProblemRepository repository)
        {
            this.repository = repository;
        }
        
        internal async Task RunAsync(string submissionId, int problemId)
        {
            var executable = @"bin\Release\netcoreapp2.1\Main.dll";

            var workspace = @"E:\ojworkspace\";

            var submissionFolder = Path.Combine(workspace, submissionId);

            var problem = repository.Get(problemId);

            var processExecutor = new ProcessExecutor();

            // TODO need to parallelize this one
            foreach (var testCase in problem.TestCases)
            {
                var processResult = await processExecutor.Run("dotnet", executable, submissionFolder, 1000, testCase.Input);

                Console.WriteLine(processResult.Output.Trim() == testCase.Output.Trim());

                // need to publish result on realtime 
            }

            Directory.Delete(submissionFolder, true);
        }

        private static Task<bool> WaitForExitAsync(Process process, int timeout)
        {
            return Task.Run(() => process.WaitForExit(timeout));
        }
    }
}
