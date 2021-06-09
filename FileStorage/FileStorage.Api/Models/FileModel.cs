using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileStorage.Api.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }
        public string ContentType { get; set; }
        public List<DisposableUrlModel> DisposableUrlModels { get; set; }
    }
}
