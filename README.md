# Library Management System Web API

## Project Overview
This project demonstrates how to build a RESTful Web API using **C#** and **ASP.NET Core**. The API allows users to perform CRUD (Create, Read, Update, Delete) operations on a simple in-memory library system. The goal is to manage book records efficiently without using a database.

---

## Features
- **Add Books:** Add new books to the library.
- **Update Books:** Update existing book details using their ISBN.
- **Remove Books:** Delete books from the library using their ISBN.
- **List All Books:** Retrieve a list of all books in the library.
- **Search Books:** Search for books by their title.
- **Error Handling:** Graceful error messages for duplicate ISBNs, missing books, and invalid inputs.

---

## Endpoints
| HTTP Method | Endpoint                 | Description                                    |
|-------------|--------------------------|------------------------------------------------|
| POST        | `/api/books`            | Add a new book to the library.                |
| PUT         | `/api/books/{isbn}`     | Update details of a book by its ISBN.         |
| DELETE      | `/api/books/{isbn}`     | Remove a book from the library by its ISBN.   |
| GET         | `/api/books`            | Retrieve a list of all books in the library.  |
| GET         | `/api/books/{title}`    | Search for books by their title.              |

---

## Book Object Structure
Each book in the library is represented as a JSON object with the following structure:
```json
{
  "title": "string",
  "author": "string",
  "isbn": "string", // Unique identifier
  "available": true // Boolean indicating availability
}
```

---

## Prerequisites
Before running this project, ensure you have the following installed:
1. **.NET SDK** (version 6.0 or higher)
2. **Visual Studio** or any code editor with C# support

---

## Getting Started

### Step 1: Clone the Repository
```bash
git clone [<repository-url>](https://github.com/RagulArvinth/LIbraryManagementAPI.git)
cd LibraryManagementSystemAPI
```

### Step 2: Run the Application
Run the application locally:
```bash
dotnet run
```
The API will be available at:
- `http://localhost:5000`
- `https://localhost:5001`

### Step 3: Test the Endpoints
You can test the endpoints using tools like:
- [Postman](https://www.postman.com/)
- [HTTPie](https://httpie.io/)
- Curl (command-line tool)

#### Example: Add a New Book
Use the `POST` endpoint to add a book:
```bash
POST http://localhost:5000/api/books
Content-Type: application/json

{
  "title": "The Great Gatsby",
  "author": "F. Scott Fitzgerald",
  "isbn": "1234567890",
  "available": true
}
```

---

## Error Handling
The API provides clear error messages for common issues:
- **Duplicate ISBN:**
  ```json
  {
    "error": "A book with this ISBN already exists."
  }
  ```
- **Book Not Found:**
  ```json
  {
    "error": "Book not found."
  }
  ```
- **Invalid Input:**
  ```json
  {
    "error": "Invalid input. Please provide all required fields."
  }
  ```

---
