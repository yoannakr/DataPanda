using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.FileSubmissions.Commands.Create
{
    public class CreateFileSubmissionPersistenceCommand : IPersistenceCommand<Result>
    {
        public CreateFileSubmissionPersistenceCommand(FileSubmission fileSubmission)
        {
            FileSubmission = fileSubmission;
        }

        public FileSubmission FileSubmission { get; }
    }
}
