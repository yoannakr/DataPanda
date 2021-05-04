using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.FileSubmissions.Queries.GetById;
using DataPanda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.FileSubmissions.Queries.GetById
{
    public class GetFileSubmissionByIdPersistenceQueryHandler : IPersistenceQueryHandler<GetFileSubmissionByIdPersistenceQuery, FileSubmission>
    {
        private readonly DataPandaDbContext context;

        public GetFileSubmissionByIdPersistenceQueryHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<FileSubmission> Handle(GetFileSubmissionByIdPersistenceQuery query)
            => await context.FileSubmissions.FirstOrDefaultAsync(fileSubmission => fileSubmission.Id == query.FileSubmissionId);
    }
}
