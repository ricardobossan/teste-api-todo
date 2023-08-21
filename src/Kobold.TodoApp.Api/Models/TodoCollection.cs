using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kobold.TodoApp.Api.Models
{
    public class TodoCollection
    {
        public string CollectionName { get; set; }
        public List<Todo> Todos { get; set; }

    }
}
