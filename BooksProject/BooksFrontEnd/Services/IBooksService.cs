using System;
using System.Collections.Generic;
using System.Linq;
using BooksFrontEnd.Models;
using System.Threading.Tasks;

namespace BooksFrontEnd.Services
{
    public interface IBooksService
    {
        public Task Add(Book entity);

        public Task Delete(int id);

        public Task<IEnumerable<Book>> GetAll();

        public Task<Book> GetById(int id);

        public Task Update(int id, Book entity);
    }
}
