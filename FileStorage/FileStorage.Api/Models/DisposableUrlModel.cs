using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileStorage.Api.Models
{
    public class DisposableUrlModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int FileModelId { get; set; }
        public FileModel FileModel { get; set; }
    }
}
