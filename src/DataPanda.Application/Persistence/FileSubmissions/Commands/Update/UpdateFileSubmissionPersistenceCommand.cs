using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.FileSubmissions.Commands.Update
{
    public class UpdateFileSubmissionPersistenceCommand : IPersistenceCommand<Result>
    {
        public UpdateFileSubmissionPersistenceCommand(FileSubmission fileSubmission)
        {
            FileSubmission = fileSubmission;
        }

        public FileSubmission FileSubmission { get; }
    }
}
