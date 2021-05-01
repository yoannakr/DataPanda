using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Features.Files.Commands.Upload;
using Microsoft.Extensions.DependencyInjection;

namespace DataPanda.Startup.IoC.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
            => services.AddScoped<ICommandHandler<UploadFileCommand, Result>, UploadFileCommandHandler>();
    }
}
