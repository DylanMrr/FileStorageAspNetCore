﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FileStorage.Api.Dtos
{
    public class FileDto
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
