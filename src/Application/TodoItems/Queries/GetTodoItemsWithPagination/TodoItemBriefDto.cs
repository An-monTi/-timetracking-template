using zeitag_grid_init.Application.Common.Mappings;
using zeitag_grid_init.Domain.Entities;

namespace zeitag_grid_init.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}
