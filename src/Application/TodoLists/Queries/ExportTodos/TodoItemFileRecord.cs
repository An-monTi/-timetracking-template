using zeitag_grid_init.Application.Common.Mappings;
using zeitag_grid_init.Domain.Entities;

namespace zeitag_grid_init.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
