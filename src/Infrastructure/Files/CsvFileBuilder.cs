using System.Globalization;
using zeitag_grid_init.Application.Common.Interfaces;
using zeitag_grid_init.Application.TodoLists.Queries.ExportTodos;
using zeitag_grid_init.Infrastructure.Files.Maps;
using CsvHelper;

namespace zeitag_grid_init.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
