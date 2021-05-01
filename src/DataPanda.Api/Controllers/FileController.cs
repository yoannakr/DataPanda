using DataPanda.Api.Extensions;
using DataPanda.Api.InputModels.File;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Features.Files.Commands.Upload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataPanda.Api.Controllers
{
    public class FileController : ApiController
    {
        private readonly ICommandHandler<UploadFileCommand, Result> uploadFileCommandHandler;

        public FileController(ICommandHandler<UploadFileCommand, Result> uploadFileCommandHandler)
        {
            this.uploadFileCommandHandler = uploadFileCommandHandler;
        }

        [HttpPost]
        public async Task<ActionResult> Upload([FromForm] UploadInputModel inputModel)
        {
            using var stream = inputModel.FormFile.OpenReadStream();
            var command = new UploadFileCommand(
                stream,
                inputModel.PlatformName,
                inputModel.PlatformType,
                inputModel.PlatformUrl,
                inputModel.CourseName,
                inputModel.CourseFieldOfApplication);

            var result = await uploadFileCommandHandler.Handle(command);

            return result.ToActionResult();
        }

        [HttpPost]
        public async Task<ActionResult> UploadMultiple(IEnumerable<IFormFile> formFiles)
        {
            return new OkResult();
        }

        [HttpPost]
        public async Task<ActionResult> UploadArchive(IFormFile formFileArchive)
        {
            return new OkResult();
        }
    }
}
