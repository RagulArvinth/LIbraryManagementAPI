using LibraryManagementAPI.Models;
using System.Collections.Generic;

namespace LibraryManagementAPI.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookByTitle(string title);
        Book GetBookByISBN(string isbn);
        void AddBook(Book newBook);
        void UpdateBook(string isbn, Book updatedBook);
        void RemoveBook(string isbn);
    }
}