using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using zeitag_grid_init.Application.Common.Interfaces;
using zeitag_grid_init.Domain.Entities;

namespace zeitag_grid_init.Application.TimeTrackings.Commands.CreateTimeTracking;

public record CreateTimeTrackingCommand : IRequest<int>
{
    public DateTime RecordStart { get; set; }
    public DateTime RecordEnd { get; set; }
    public string? ShortDescription { get; set; }
    public int Type { get; set; }
}

public class CreateTimeTrackingCommandHandler : IRequestHandler<CreateTimeTrackingCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTimeTrackingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTimeTrackingCommand request, CancellationToken cancellationToken)
    {
        var entity = new TimeTracking();

        entity.RecordStart = request.RecordStart;
        entity.RecordEnd = request.RecordEnd;
        entity.ShortDescription = request.ShortDescription;
        entity.Type = request.Type;

        _context.TimeTracking.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
