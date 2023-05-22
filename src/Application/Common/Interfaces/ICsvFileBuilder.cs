using zeitag_grid_init.Application.TodoLists.Queries.ExportTodos;

namespace zeitag_grid_init.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
