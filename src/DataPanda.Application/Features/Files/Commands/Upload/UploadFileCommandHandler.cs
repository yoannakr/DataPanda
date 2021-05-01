using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Contracts.Parsers;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Files.Commands.Upload
{
    public class UploadFileCommandHandler : ICommandHandler<UploadFileCommand, Result>
    {
        private readonly IStudentResultParser studentResultParser;

        public UploadFileCommandHandler(IStudentResultParser studentResultParser)
        {
            this.studentResultParser = studentResultParser;
        }

        public async Task<Result> Handle(UploadFileCommand command)
        {
            var result = await studentResultParser.Parse(command.FileStream);

            return Result.Success();
        }
    }
}
