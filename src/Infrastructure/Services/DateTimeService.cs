using zeitag_grid_init.Application.Common.Interfaces;

namespace zeitag_grid_init.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
