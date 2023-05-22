using zeitag_grid_init.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace zeitag_grid_init.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    //Datenbankeintragung
    DbSet<TimeTracking> TimeTracking { get; }
    DbSet<BookingTypes> BookingTypes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
