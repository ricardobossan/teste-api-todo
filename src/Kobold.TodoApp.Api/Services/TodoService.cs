using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kobold.TodoApp.Api.Models;

namespace Kobold.TodoApp.Api.Services
{

    public class TodoService
    {

        private static int nextId = 1;
        private static List<Todo> Todos = new List<Todo>();
        private readonly TodoDbContext _dbContext;

        public TodoService(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Todo> Get()
        {
            return _dbContext.Todos;
        }

        public Todo Create(TodoViewModel todovm)
        {
            var todo = new Todo { Id = nextId++, DataCriacao = DateTime.Now, Description = todovm.Description, Done = todovm.Done };
            _dbContext.Todos.Add(todo);
            _dbContext.SaveChanges();
            return todo;
        }

        public Todo Update(int id, TodoViewModel todovm)
        {
            var todo = _dbContext.Todos.Single(todo => todo.Id == id);
            todo.Done = todovm.Done;
            todo.Description = todovm.Description;
            _dbContext.SaveChanges();

            return todo;
        }

        public Todo Get(int id)
        {
            return _dbContext.Todos.Single(todo => todo.Id == id);
        }

        public bool Remove(int id)
        {
            var todo = Get(id);
            if (todo != null)
            {
                var index = _dbContext.Todos.Remove(todo);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
