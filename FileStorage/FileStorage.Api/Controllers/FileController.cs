using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileStorage.Api.Dtos;
using FileStorage.Api.Models;
using FileStorage.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileStorage.Api.Services;

namespace FileStorage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;
        private readonly IUrlGenerator _urlGenerator;
        private readonly IDisposableUrlRepository _disposableUrlRepository;

        public FileController(IFileRepository fileRepository,
            IUrlGenerator urlGenerator,
            IDisposableUrlRepository disposableUrlRepository)
        {
            _fileRepository = fileRepository;
            _urlGenerator = urlGenerator;
            _disposableUrlRepository = disposableUrlRepository;
        }

        //todo трай кэтч
        [HttpPost("addfile")]
        public async Task<IActionResult> AddFile(IFormFile fileDto)
        {
            if (fileDto is null)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            FileModel fileModel = new FileModel();
            byte[] fileBytes;
            using (var binaryReader = new BinaryReader(fileDto.OpenReadStream()))
            {
                fileBytes = binaryReader.ReadBytes((int)fileDto.Length);
            }
            fileModel.File = fileBytes;
            fileModel.Name = fileDto.FileName;
            fileModel.ContentType = fileDto.ContentType;
            await _fileRepository.Add(fileModel);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var file = await _fileRepository.Get(id);
            return File(file.File, file.ContentType);

        }

        [HttpGet("geturl/{id}")]
        public async Task<ActionResult<string>> GetUrl(int id)
        {
            string url = _urlGenerator.Generate();
            FileModel file = await _fileRepository.Get(id);
            DisposableUrlModel disposableUrlModel = new DisposableUrlModel()
            {
                Url = url,
                FileModel = file
            };
            //file.DisposableUrlModel = disposableUrlModel;
            await _fileRepository.Update(file);
            await _disposableUrlRepository.Add(disposableUrlModel);
            return $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/api/file/download/{url}";
        }

        [HttpGet("download/{disposableUrl}")]
        public async Task<ActionResult> Download(string disposableUrl)
        {
            DisposableUrlModel disposableUrlModel = await _disposableUrlRepository.GetByUrl(disposableUrl);
            FileModel fileModel = await _fileRepository.Get(disposableUrlModel.FileModelId);
            await _disposableUrlRepository.Delete(disposableUrlModel.Id);
            return File(fileModel.File, fileModel.ContentType);
        }
    }
}