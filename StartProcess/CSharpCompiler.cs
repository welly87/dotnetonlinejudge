using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace StartProcess
{
    internal class CSharpCompiler
    {
        private static void PrepareDirectory(string submissionId)
        {
            var folderPath = submissionId.ToString();

            var workspace = @"E:\ojworkspace";

            Directory.CreateDirectory(Path.Combine(workspace, folderPath));
        }

        public async Task<CompileResult> CompileAsync(string submissionId, string sourceCode)
        {
            PrepareDirectory(submissionId);

            var workspace = @"E:\ojworkspace\";

            File.Copy(@"E:\ojworkspace\Main.csproj", Path.Combine(workspace, submissionId, "Main.csproj"));

            var submissionFolder = Path.Combine(@"E:\ojworkspace", submissionId);

            File.WriteAllText(Path.Combine(submissionFolder, "Program.cs"), sourceCode);

            var processExecutor = new ProcessExecutor();

            // TODO need to make a timeout, don't use default value in production
            var result = await processExecutor.Run("dotnet", "build -c Release", submissionFolder, int.MaxValue, null);

            var buildSucceed = result.Output.Contains("Build succeeded.");

            return new CompileResult
            {
                Success = buildSucceed,
                Output = result.Output, 
                Error = result.Error
            };
        }
    }
}