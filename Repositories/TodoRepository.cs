using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo_BE.Models;

namespace Todo_BE.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;
        

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }
        public async Task<Todo> Create(Todo todo)
        {
            _context.todos.Add(todo);
            _ = await _context.SaveChangesAsync();
            return todo;
        }

        public async Task Delete(int id)
        {
            var todoToDelete = await _context.todos.FindAsync(id);
            _context.todos.Remove(todoToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Todo>> Get()
        {
            return await _context.todos.ToListAsync();
        }


        public async Task<Todo> Get(int id)
        {
            return await _context.todos.FindAsync(id);
        }

        public async Task Update(Todo todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
