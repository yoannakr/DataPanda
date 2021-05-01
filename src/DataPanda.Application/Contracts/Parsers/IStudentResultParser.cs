using DataPanda.Application.Features.Files.Models;
using System.Collections.Generic;

namespace DataPanda.Application.Contracts.Parsers
{
    public interface IStudentResultParser : IParser<IEnumerable<StudentResult>>
    {
    }
}
