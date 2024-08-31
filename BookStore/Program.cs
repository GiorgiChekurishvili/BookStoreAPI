using BookStore.Data;
using BookStore.Repositories.AuthorRepository;
using BookStore.Repositories.BookGenresRepository;
using BookStore.Repositories.BookRepository;
using BookStore.Repositories.GenreRepository;
using BookStore.Repositories.PublisherRepository;
using BookStore.Services.AuthorService;
using BookStore.Services.BookService;
using BookStore.Services.GenreService;
using BookStore.Services.PublisherService;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookStoreContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookGenresRepository, BookGenresRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IPublisherRepository , PublisherRepository>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
