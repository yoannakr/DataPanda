using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DataPanda.Api.Controllers
{
    public class FileController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult> Upload(IEnumerable<IFormFile> formFiles)
        {
            foreach (var formFile in formFiles)
            {
                var result = new StringBuilder();
                using (var reader = new StreamReader(formFile.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                        result.AppendLine(await reader.ReadLineAsync());
                }
                var a = result.ToString();
            }

            return new OkResult();
        }
    }
}
