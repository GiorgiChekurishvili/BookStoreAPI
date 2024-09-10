# BookStoreAPI

BookStoreAPI is a web API designed to manage books, authors, publishers, and user interactions such as reviews and ratings. Built using ASP.NET Core, Entity Framework Core, and JWT authentication, it provides functionality for a bookstore with support for user roles (admin, customer) and data relationships between books, authors, and publishers.

## Features

- **Book Management**: Add, update, delete, and browse books.
- **Author & Publisher Management**: Manage authors and publishers associated with books.
- **User Reviews and Ratings**: Users can submit and manage reviews and ratings for books.
- **Authentication & Authorization**: Supports JWT-based authentication for role-based access (admins and customers).
- **Advanced Search**: Search books by title, author, genre, etc.

## Technologies Used

- **ASP.NET Core**
- **Entity Framework Core**
- **JWT Authentication**
- **SQL Server**

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/GiorgiChekurishvili/BookStoreAPI.git
    ```

2. **Navigate to the project directory:**

    ```bash
    cd BookStoreAPI
    ```

3. **Restore dependencies:**

    ```bash
    dotnet restore
    ```

4. **Update `appsettings.json` with your connection string for example:**

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=BookStoreDB;TrustServerCertificate=True;Trusted_Connection=True; "
    }
    ```

5. **Apply database migrations:**

    ```bash
    dotnet ef database update
    ```

6. **Run the application:**

    ```bash
    dotnet run
    ```

## API Endpoints

### Authentication

- **POST** `/api/auth/register`: Register a new user.
- **POST** `/api/auth/login`: Log in using JWT.

### Books

- **GET** `/api/books`: Get a list of books.
- **GET** `/api/books/{id}`: Get a specific book by ID.
- **POST** `/api/books`: Create a new book (Admin only).
- **PUT** `/api/books/{id}`: Update a book (Admin only).
- **DELETE** `/api/books/{id}`: Delete a book (Admin only).

### Authors

- **GET** `/api/authors`: Get a list of authors.
- **POST** `/api/authors`: Create a new author (Admin only).

### Publishers

- **GET** `/api/publishers`: Get a list of publishers.
- **POST** `/api/publishers`: Create a new publisher (Admin only).

### Reviews

- **POST** `/api/reviews`: Submit a review for a book.
- **GET** `/api/reviews/book/{bookId}`: Get reviews for a specific book.

## Contributing

Feel free to submit pull requests or open issues to contribute.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
