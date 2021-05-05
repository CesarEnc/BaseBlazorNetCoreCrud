using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;

namespace BooksAPI.Repositories
{
    public interface IBookRepository
    {
        public Task Add(Book entity);

        public Task Delete(int id);

        public Task<IEnumerable<Book>> GetAll();

        public Task<Book> GetById(int id);

        public Task Update(Book entity);
    }
}
