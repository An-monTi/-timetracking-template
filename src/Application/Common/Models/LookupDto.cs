using zeitag_grid_init.Application.Common.Mappings;
using zeitag_grid_init.Domain.Entities;

namespace zeitag_grid_init.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<TodoList>, IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
