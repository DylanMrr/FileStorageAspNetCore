using FileStorage.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileStorage.Api.Repositories
{
    public class DisposableUrlRepository: BaseEntityFrameworkRepository<DisposableUrlModel>, IDisposableUrlRepository
    {
        public DisposableUrlRepository(FileContext fileContext): base(fileContext) { }

        public async Task<DisposableUrlModel> GetByUrl(string url)
        {
            return await _db.Set<DisposableUrlModel>().Where(d => d.Url == url).FirstOrDefaultAsync();
        }
    }
}
