using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FileStorage.Api.Dtos
{
    public class FilesDto
    {
        public IFormCollection Files { get; set; }
    }
}
