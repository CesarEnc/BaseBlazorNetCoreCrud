using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;

namespace BooksAPI.Repositories
{
    /// <summary> Book Service used to comunicate with data-layer. </summary>
    public class BookRepository : IBookRepository
    {
        public Task Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
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

        public Task Update(int id, Book entity)
        {
            throw new NotImplementedException();
        }

    }
}
