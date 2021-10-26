using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo_BE.Models;

namespace Todo_BE.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> Get();
        Task<Todo> Get(int id);
        Task<Todo> Create(Todo todo);
        Task Update(Todo todo);

        Task Delete(int id);
    }
}
