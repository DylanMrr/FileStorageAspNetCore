using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileStorage.Api.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id); // получение одного объекта по id
        Task Add(T item); // создание объекта
        Task Update(T item); // обновление объекта
        Task Delete(int id); // удаление объекта по id
        Task Save();  // сохранение изменений
    }
}
