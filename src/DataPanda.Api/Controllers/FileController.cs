using DataPanda.Api.Extensions;
using DataPanda.Api.InputModels.File;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Features.Files.Commands.Upload;
using DataPanda.Application.Features.Files.Commands.UploadArchive;
using DataPanda.Application.Features.Files.Commands.UploadMultiple;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DataPanda.Api.Controllers
{
    public class FileController : ApiController
    {
        private readonly ICommandHandler<UploadFileCommand, Result> uploadFileCommandHandler;
        private readonly ICommandHandler<UploadMultipleFilesCommand, Result> uploadMultipleFilesCommandHandler;
        private readonly ICommandHandler<UploadFileArchiveCommand, Result> uploadFileArchiveCommandHandler;

        public FileController(
            ICommandHandler<UploadFileCommand, Result> uploadFileCommandHandler,
            ICommandHandler<UploadMultipleFilesCommand, Result> uploadMultipleFilesCommandHandler,
            ICommandHandler<UploadFileArchiveCommand, Result> uploadFileArchiveCommandHandler)
        {
            this.uploadFileCommandHandler = uploadFileCommandHandler;
            this.uploadMultipleFilesCommandHandler = uploadMultipleFilesCommandHandler;
            this.uploadFileArchiveCommandHandler = uploadFileArchiveCommandHandler;
        }

        [HttpPost]
        public async Task<ActionResult> Upload([FromForm] UploadInputModel inputModel)
        {
            using var stream = inputModel.FormFile.OpenReadStream();
            var command = new UploadFileCommand(
                inputModel.PlatformName,
                inputModel.PlatformType,
                inputModel.PlatformUrl,
                inputModel.CourseName,
                inputModel.CourseFieldOfApplication,
                stream);

            var result = await uploadFileCommandHandler.Handle(command);

            return result.ToActionResult();
        }

        [HttpPost]
        public async Task<ActionResult> UploadMultiple([FromForm] UploadMultipleInputModel inputModel)
        {
            var fileStreams = new List<Stream>();
            foreach (var formFiles in inputModel.FormFiles)
            {
                var stream = formFiles.OpenReadStream();
                fileStreams.Add(stream);
            }

            var command = new UploadMultipleFilesCommand(
                inputModel.PlatformName,
                inputModel.PlatformType,
                inputModel.PlatformUrl,
                inputModel.CourseName,
                inputModel.CourseFieldOfApplication,
                fileStreams);

            var result = await uploadMultipleFilesCommandHandler.Handle(command);

            foreach (var fileStream in fileStreams)
            {
                await fileStream.DisposeAsync();
            }

            return result.ToActionResult();
        }

        [HttpPost]
        public async Task<ActionResult> UploadArchive([FromForm] UploadArchiveInputModel inputModel)
        {
            using var stream = inputModel.FormFile.OpenReadStream();
            var command = new UploadFileArchiveCommand(
                inputModel.PlatformName,
                inputModel.PlatformType,
                inputModel.PlatformUrl,
                inputModel.CourseName,
                inputModel.CourseFieldOfApplication,
                stream);

            var result = await uploadFileArchiveCommandHandler.Handle(command);

            return result.ToActionResult();
        }
    }
}
