using BooksAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Repositories
{
    /// <summary> Book Service used to do in-memory testing. </summary>
    public class MockBookRepository : IBookRepository
    {
        private List<Book> Books = new List<Book>();

        public MockBookRepository()
        {
            LoadJson(Environment.GetEnvironmentVariable("MockDataFile"));
        }

        public async Task Add(Book book) => await Task.Run(() =>
            {
                book.id = Books.Max(book => book.id) + 1;
                Books.Add(book);
            });

        public async Task<bool> Delete(int id) => await Task.Run(() => Books.Remove(Books.Where(book => book.id == id).FirstOrDefault()));

        public async Task<IEnumerable<Book>> GetAll() => await Task.Run(() => Books);

        public async Task<Book> GetById(int id) => await Task.Run(() => Books.Where(book => book.id == id).FirstOrDefault());

        public async Task Update(int id, Book entity)
        {
            //I discovered that this implementation would actually be a Patch request
            //Commented since it could be usefull. #!(TimeWaster).
            //
            //await Task.Run(() =>
            //    Books.IndexOf(Books.Where(book => book.id == id).FirstOrDefault()))
            //    .ContinueWith((i) =>
            //    {
            //        int index = i.Result;
            //        foreach (var prop in typeof(Book).GetProperties())
            //        {
            //            if (prop.GetValue(entity) == null) continue;
            //            else prop.SetValue(Books[index], prop.GetValue(entity), null);
            //        }
            //    });

            await Task.Run(() =>
           {
               entity.id = id;
               Books[Books.IndexOf(Books.Where(book => book.id == id).FirstOrDefault())] = entity;
           });
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