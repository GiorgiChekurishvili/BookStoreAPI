# BookStore API
Overview
The BookStore API is a RESTful web service that allows users to interact with a bookstore. It provides functionality for user authentication, book and author management, transaction processing, and more. The API is built using ASP.NET Core with JWT-based authentication.

## Features

- **User Authentication**: Register and login users.
- **Author Management**: Create, update, view, and delete authors.
- **Book Management**: View, upload, update, and delete books.
- **Genre & Publisher Management**: Handle genres and publishers.
- **Transactions**: Process book purchases and manage user balances.
  
## Technologies Used

- **ASP.NET Core**
- **Entity Framework Core**
- **AutoMapper**
- **JWT Authentication**
- **Swagger**

  ## Getting Started
  ### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

  ## Installation
  
1. ## Clone the repository:
    ```bash
    git clone https://github.com/GiorgiChekurishvili/BookStoreAPI.git
    ```

2. ## Navigate to the BookStore directory:
    ```bash
    cd  BookStore
    ```
3. **Restore dependencies:**

    ```bash
    dotnet restore
    ```

4. ## Set up the database connection in appsettings.json:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=BookStoreDB;Trusted_Connection=True;"
    }
    ```
5. ## Run migrations to set up the database:
    ```bash
    dotnet ef database update
    ```
6. ## Run the project:
    ```bash
    dotnet run
    ```
## Endpoints
## Authentication
- POST `/api/authentication/register`: Register a new user.
- POST `/api/authentication/login`: Log in an existing user.
  
## Books
- GET `/api/book/allbooks`: View all books.
- - GET `/api/book/getbookbyid/{id}`: View all books.
- POST `/api/book/uploadbook`: Upload a new book (Admin only).
- PUT `/api/book/updatebook/{id}`: Update an existing book (Admin only).
- DELETE `/api/book/deletebook/{id}`: Delete a book (Admin only).
  
## Authors
- GET `/api/author/getallauthors`: View all authors.
- POST `/api/author/uploadauthor`: Upload a new author (Admin only).
- PUT `/api/author/updateauthor/{id}`: Update an existing author (Admin only).
- DELETE `/api/author/deleteauthor/{id}`: Delete an author (Admin only)

  ## Genre
- GET `/api/genre/viewallgenres`: View all genres.
- GET `/api/genre/viewgenrebyid/{id}`: View Genre by Id.
- POST `/api/genre/creategenre`: Create a new genre (Admin only).
- PUT `/api/genre/updategenre/{id}/{genreName}`: Update a existing Genre (Admin only).
- DELETE `/api/genre/deletegenre/{id}`: Delete Genre (Admin only)

    ## Genre
- GET `/api/publisher/getallpublishers`: View all Publishers.
- GET `/api/publisher/getpublisherbyid/{id}`: View publisher by Id.
- POST `/api/publisher/uploadpublisher`: add a new publisher (Admin only).
- PUT `/api/publisher/updatepublisher/{id}`: Update a existing publisher (Admin only).
- DELETE `/api/publisher/deletepublisher/{id}`: Delete publisher (Admin only)
  
## Transactions
- POST `/api/transaction/fillbalance/{deposit}`: Fill user balance.
- POST `/api/transaction/buybook/{bookId}/{bookQuantity}`: Purchase a book.
- GET `/api/transaction/viewmybalance`: View user's balance (Member only).
- GET `/api/transaction/viewmybooks`: View user's bought books (Member only).
## Security
JWT authentication is used for securing the endpoints.
Different user roles like Admin and Member are managed.
# License
This project is licensed under the MIT License.


