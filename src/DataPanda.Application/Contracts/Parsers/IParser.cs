using DataPanda.Application.Contracts.CQRS.Results;
using System.IO;
using System.Threading.Tasks;

namespace DataPanda.Application.Contracts.Parsers
{
    public interface IParser<TParsedResult>
    {
        Task<Result<TParsedResult>> Parse(Stream streamToParse);
    }
}
