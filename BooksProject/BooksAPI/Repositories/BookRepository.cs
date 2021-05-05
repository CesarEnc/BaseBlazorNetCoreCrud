using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;

namespace BooksAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        public Task Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Book entity)
        {
            throw new NotImplementedException();
        }

    }
}
