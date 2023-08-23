using System;
using Microsoft.EntityFrameworkCore;

namespace Kobold.TodoApp.Api.Models
{
    public static class TodoSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                new Todo
                {
                    Id = -1,
                    DataCriacao = DateTime.Now,
                    Done = true,
                    Description = "Procurar receita"
                },
                new Todo
                {
                    Id = -2,
                    DataCriacao = DateTime.Now,
                    Done = true,
                    Description = "Comprar ingredientes"
                },
                new Todo
                {
                    Id = -3,
                    DataCriacao = DateTime.Now,
                    Done = false,
                    Description = "Cozinhar receita"
                },
                new Todo
                {
                    Id = -4,
                    DataCriacao = DateTime.Now,
                    Done = false,
                    Description = "Servir mesa"
                }
            );
        }
    }
}

