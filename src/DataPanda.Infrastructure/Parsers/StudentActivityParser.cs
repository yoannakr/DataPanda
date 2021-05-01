using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Contracts.Parsers;
using DataPanda.Application.Features.Files.Models;
using System.IO;
using System.Threading.Tasks;

namespace DataPanda.Infrastructure.Parsers
{
    public class StudentActivityParser : IParser<StudentActivity>
    {
        public Task<Result<StudentActivity>> Parse(Stream streamToParse)
        {
            throw new System.NotImplementedException();
        }
    }
}
