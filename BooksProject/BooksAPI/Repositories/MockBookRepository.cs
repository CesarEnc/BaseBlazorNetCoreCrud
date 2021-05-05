using BooksAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Repositories
{
    public class MockBookRepository : IBookRepository
    {
        private List<Book> Books = new List<Book>();

        public MockBookRepository()
        {
            LoadJson("TestData.json");
        }
        public async Task Add(Book book) => await Task.Run(() => Books.Add(book));
        public async Task Delete(int id) => await Task.Run(() => Books.Remove(Books.Where(book => book.id == id).FirstOrDefault()));
        public async Task<IEnumerable<Book>> GetAll() => await Task.Run(() => Books);
        public async Task<Book> GetById(int id) => await Task.Run(() => Books.Where(book => book.id == id).FirstOrDefault());
        public async Task Update(Book book)
        {
            await Task.Run(() =>
            Books.Remove(Books.Where(x => x.id == book.id).FirstOrDefault())
            ).ContinueWith((response) => Books.Add(book));
        }
        private void LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                Books = JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }
    }
}
