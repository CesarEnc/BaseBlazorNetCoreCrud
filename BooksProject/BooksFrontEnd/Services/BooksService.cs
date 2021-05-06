using BooksFrontEnd.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BooksFrontEnd.Services
{
    public class BooksService : IBooksService
    {
        private HttpClient _client;
        private readonly string _baseUri = Environment.GetEnvironmentVariable("BaseApiPoint");
        public BooksService()
        {
            _client = new HttpClient();
        }
        public Task Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id) => await _client.DeleteAsync($"{_baseUri}Books/{id}");
        

        public async Task<IEnumerable<Book>> GetAll()
        {
            string test = $"{_baseUri}Books/";
            var result = await _client.GetStringAsync(test);
            return JsonConvert.DeserializeObject<List<Book>>(result);
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
