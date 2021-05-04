using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.FileSubmissions.Queries.GetById
{
    public class GetFileSubmissionByIdPersistenceQuery : IPersistenceQuery<FileSubmission>
    {
        public GetFileSubmissionByIdPersistenceQuery(int fileSubmissionId)
        {
            FileSubmissionId = fileSubmissionId;
        }

        public int FileSubmissionId { get; }
    }
}
