using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var submissionId = Guid.NewGuid();

            PrepareDirectory(submissionId);

            Compile(submissionId.ToString(), System.IO.File.ReadAllText(@"C:\Users\welly\Source\Repos\Main\Main\Program.cs"));
        }

        private static void PrepareDirectory(Guid submissionId)
        {
            var folderPath = submissionId.ToString();

            var workspace = @"E:\ojworkspace";

            Directory.CreateDirectory(Path.Combine(workspace, folderPath));
        }

        private static void Compile(string submissionId, string sourceCode)
        {
            var workspace = @"E:\ojworkspace\";

            System.IO.File.Copy(@"E:\ojworkspace\Main.csproj", Path.Combine(workspace, submissionId, "Main.csproj"));

            var submissionFolder = Path.Combine(@"E:\ojworkspace", submissionId);

            System.IO.File.WriteAllText(Path.Combine(submissionFolder, "Program.cs"), sourceCode);

            Process.Start("dotnet", $"build --source {submissionFolder} -c Release -o {submissionFolder}");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
