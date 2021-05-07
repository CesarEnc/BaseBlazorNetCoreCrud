using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BooksAPI.Models;
using Newtonsoft.Json;

namespace BooksAPI.Repositories
{
    /// <summary> Book Service used to comunicate with data-layer. </summary>
    public class BookRepository : IBookRepository
    {
        private HttpClient _client;
        private readonly string _baseUri = Environment.GetEnvironmentVariable("BaseDataPoint");

        public BookRepository()
        {
            _client = new HttpClient() ;
        }
        public async Task Add(Book entity)
        {
            string url = $"{_baseUri}Books/";
            string data = JsonConvert.SerializeObject(entity);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            await _client.PostAsync(url, content);
        }

        public async Task<bool> Delete(int id)
        {
            var res = await _client.DeleteAsync($"{_baseUri}Books/{id}");
            return res.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            string url = $"{_baseUri}Books/";
            var result = await _client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<Book>>(result);
        }

        public async Task<Book> GetById(int id)
        {
            string url = $"{_baseUri}Books/{id}";
            var result = await _client.GetStringAsync(url);
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
