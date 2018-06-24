using System;
using System.IO;
using System.Threading.Tasks;

namespace StartProcess
{
    // https://gist.github.com/AlexMAS/276eed492bc989e13dcce7c78b9e179d

    class Program
    {
        static void Main(string[] args)
        {   
            var gradeNewSubmission = new GradeNewSubmission
            {
                Id = Guid.NewGuid(), 
                ProblemId = 2532,
                SourceCode = File.ReadAllText(@"C:\Users\welly\Source\Repos\Main\Main\Program.cs")
            };

            var submissionId = gradeNewSubmission.Id;
            
            var compiler = new CSharpCompiler();

            var compileResult = compiler.CompileAsync(submissionId.ToString(), gradeNewSubmission.SourceCode).Result;

            var problemId = gradeNewSubmission.ProblemId;

            if (compileResult.Success)
            {
                RunSumbissionAsync(submissionId.ToString(), problemId).Wait();
            }
            else
            {
                Console.WriteLine($"Compile Error {compileResult.Output}");
            }
        }

        private static async Task RunSumbissionAsync(string submissionId, int problemId)
        {
            var repository = new ProblemRepository();
            
            var workspace = @"E:\ojworkspace\";

            var submissionFolder = Path.Combine(workspace, submissionId);

            var submissionRunner = new SubmissionRunner(repository);

            await submissionRunner.RunAsync(submissionId, problemId);
        }

    }
}
