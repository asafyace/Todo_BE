using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo_BE.Models;
using Todo_BE.Repositories;

namespace Todo_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Todo>> GetTodos()
        {
            return await _todoRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id) 
        {
            return await _todoRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>>PostTodo([FromBody] Todo todo)
        {
            var newTodo = await _todoRepository.Create(todo);
            return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, newTodo);
        }
        [HttpPut]
        public async Task<ActionResult<Todo>> PutTodo(int id, [FromBody] Todo todo)
        {
           if(todo.Id != id)
            {
                return BadRequest();
            }
            await _todoRepository.Update(todo);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult<Todo>> PutTodo(int id)
        {
            var TodoToDelete = await _todoRepository.Get(id);
            if(TodoToDelete == null)
            {
                return NotFound();
            }
            await _todoRepository.Delete(id);
            return NoContent();
        }

    }
}
