using System.Globalization;
using zeitag_grid_init.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace zeitag_grid_init.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).Convert(c => c.Value.Done ? "Yes" : "No");
    }
}
