﻿global using Microsoft.EntityFrameworkCore;
using BookStore.Entities;


namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
            
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(a => a.Id);
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).IsRequired().HasMaxLength(128);
            modelBuilder.Entity<Author>().Property(a => a.Biography).IsRequired();
            modelBuilder.Entity<Author>().Property(a => a.DateOfBirth).HasDefaultValue("Unknown");
            modelBuilder.Entity<Author>().Property(a=>a.DateOfDeath).HasDefaultValue("Unknown");
            


            modelBuilder.Entity<Book>().HasKey(a => a.Id);
            modelBuilder.Entity<Book>().Property(x => x.AddedDate).HasDefaultValueSql("SYSDATETIME()");
            modelBuilder.Entity<Book>().HasOne(x => x.Publisher).WithMany(x => x.Books).HasForeignKey(x => x.PublisherId);
            modelBuilder.Entity<Book>().HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId);
            modelBuilder.Entity<Book>().Property(b => b.BookName).IsRequired().HasMaxLength(64);
            modelBuilder.Entity<Book>().Property(b=>b.Description).IsRequired().HasMaxLength(512);
            modelBuilder.Entity<Book>().Property(b => b.ReleaseDate).IsRequired();
            modelBuilder.Entity<Book>().Property(b=>b.AuthorId).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Price).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.StockQuantity).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.AgeRecommend).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Language).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.PublisherId).IsRequired();


            modelBuilder.Entity<Genre>().HasKey(a => a.Id);
            modelBuilder.Entity<Genre>().Property(g => g.GenreName).IsRequired().HasMaxLength(64);

            modelBuilder.Entity<BookGenre>().HasKey(bg => bg.Id);
            modelBuilder.Entity<BookGenre>().HasOne(bg => bg.Book).WithMany(b => b.Genres).HasForeignKey(x => x.BookId);
            modelBuilder.Entity<BookGenre>().HasOne(bg => bg.Genre).WithMany(g => g.Books).HasForeignKey(x => x.GenreId);

            modelBuilder.Entity<Publisher>().HasKey(a => a.Id);
            modelBuilder.Entity<Publisher>().Property(p => p.PublisherName).IsRequired().HasMaxLength(128);

            modelBuilder.Entity<Role>().HasKey(a => a.Id);
            modelBuilder.Entity<Role>().Property(x => x.Name).IsRequired().HasMaxLength(32);

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId);
            modelBuilder.Entity<User>().Property(x => x.RoleId).HasDefaultValue(1);

            modelBuilder.Entity<Transaction>().HasKey(x => x.Id);
            modelBuilder.Entity<Transaction>().HasOne(x => x.book).WithMany(x => x.Transactions).HasForeignKey(x => x.BookId);
            modelBuilder.Entity<Transaction>().HasOne(x => x.user).WithMany(x => x.Transactions).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Transaction>().Property(x => x.BoughtDatetime).HasDefaultValueSql("SYSDATETIME()");
        }
    }
}
