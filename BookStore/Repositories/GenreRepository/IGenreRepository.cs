﻿using BookStore.DTOs;
using BookStore.Entities;

namespace BookStore.Repositories.GenreRepository
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetGenres();
        Task<Genre?> GetGenreById(int id);
        Task<Genre?> InputGenres(Genre genre);
        Task UpdateGenres(Genre genre);
        Task DeleteGenre(int id);


    }
}
