using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileStorage.Api.Models
{
    public class FileContext: DbContext
    {
        public DbSet<FileModel> Files { get; set; }
        public DbSet<DisposableUrlModel> Urls { get; set; }

        public FileContext(DbContextOptions<FileContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
