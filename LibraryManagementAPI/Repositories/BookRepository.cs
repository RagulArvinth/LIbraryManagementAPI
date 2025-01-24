using LibraryManagementAPI.Models;
using LibraryManagementAPI.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>();

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookByTitle(string title)
        {
            return books.FirstOrDefault(book => book.Title.Contains(title, System.StringComparison.OrdinalIgnoreCase));
        }

        public Book GetBookByISBN(string isbn)
        {
            return books.FirstOrDefault(book => book.ISBN == isbn);
        }

        public void AddBook(Book newBook)
        {
            books.Add(newBook);
        }

        public void UpdateBook(string isbn, Book updatedBook)
        {
            Book existingBook = GetBookByISBN(isbn);
            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title;
                existingBook.Author = updatedBook.Author;
                existingBook.IsAvailable = updatedBook.IsAvailable;
            }
        }

        public void RemoveBook(string isbn)
        {
            Book bookToRemove = GetBookByISBN(isbn);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }
        }
    }
}
