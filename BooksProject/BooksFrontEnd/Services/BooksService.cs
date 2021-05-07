using BooksFrontEnd.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public async Task Add(Book entity)
        {
            string url = $"{_baseUri}Books/";
            string data = JsonConvert.SerializeObject(entity);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            await _client.PostAsync(url, content);
        }

        public async Task Delete(int id) => await _client.DeleteAsync($"{_baseUri}Books/{id}");
        

        public async Task<IEnumerable<Book>> GetAll()
        {
            string test = $"{_baseUri}Books/";
            var result = await _client.GetStringAsync(test);
            return JsonConvert.DeserializeObject<List<Book>>(result);
        }

        public async Task<Book> GetById(int id)
        {
            string test = $"{_baseUri}Books/{id}";
            var result = await _client.GetStringAsync(test);
            return JsonConvert.DeserializeObject<Book>(result);
        }

        public async Task Update(int id, Book entity)
        {
            string url = $"{_baseUri}Books/{id}";
            string data = JsonConvert.SerializeObject(entity);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            await _client.PutAsync(url, content);
        }
    }
}
