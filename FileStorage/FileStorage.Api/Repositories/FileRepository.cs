using FileStorage.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileStorage.Api.Repositories
{
    public class FileRepository: BaseEntityFrameworkRepository<FileModel>, IFileRepository
    {
        public FileRepository(FileContext context): base(context) { }
    }
}
