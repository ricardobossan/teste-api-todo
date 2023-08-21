using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kobold.TodoApp.Api.Models;
using Kobold.TodoApp.Api.Services;

namespace Kobold.TodoApp.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {

        private readonly TodoService _todoService;
        private readonly ILogger<TodosController> _logger;

        public TodosController(ILogger<TodosController> logger, TodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> Get()
        {
            try
            {
                IEnumerable<Todo> todos = _todoService.Get();

                if (todos == null) return NotFound("Não encontrado");

                if (!todos.Any()) return StatusCode(204);

                return Ok(todos);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ocorreu um erro ao processar a requisição");
                return StatusCode(500, "Erro no servidor");
            }
        }

        [HttpGet("collections")]
        public ActionResult<IEnumerable<TodoCollection>> GetTodoCollections()
        {
            try
            {
                var doneTodos = _todoService.Get().Where(todo => todo.Done);
                var notDoneTodos = _todoService.Get().Where(todo => !todo.Done);

                var collections = new List<TodoCollection>();

                if (doneTodos.Any()) collections.Add(new TodoCollection { CollectionName = "Done", Todos = doneTodos.ToList() });
                if (notDoneTodos.Any()) collections.Add(new TodoCollection { CollectionName = "NotDone", Todos = notDoneTodos.ToList() });

                if (collections == null) return NotFound("Não encontrado");

                if (!collections.Any()) return StatusCode(204);

                return Ok(collections);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ocorreu um erro ao processar a requisição");
                return StatusCode(500, "Erro no servidor");
            }
        }

        [HttpPost]
        public ActionResult<Todo> Create([FromBody] TodoViewModel todovm)
        {
            try
            {
                Todo todo = _todoService.Create(todovm);
                return Ok(todo);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao criar tarefa");
                return StatusCode(500, "Erro ao criar tarefa");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Todo> Update([FromRoute] int id, [FromBody] TodoViewModel todovm)
        {
            try
            {
                Todo todo = _todoService.Update(id, todovm);
                if (todo == null) return NotFound("Tarefa não encontrada");
                return Ok(todo);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ocorreu erro ao atualizar tarefa");
                return StatusCode(500, "Ocorreu erro ao atualizar tarefa");
            }

        }

        [HttpGet("{id}")]
        public ActionResult<Todo> Get([FromRoute] int id)
        {
            try
            {
                Todo todo = _todoService.Get(id);
                if (todo == null) return NotFound("Tarefa não encontrada");


                return Ok(todo);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ocorreu erro ao consultar tarefa");
                return StatusCode(500, "Ocorreu erro ao consultar tarefa");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            try
            {
                var removido = _todoService.Remove(id);
                if (!removido) return NotFound("Não encontrado");

            return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao remover tarefa");
                return StatusCode(500, "Erro ao remover tarefa");
            }
        }

    }
}
