using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using zeitag_grid_init.Application.Common.Exceptions;
using zeitag_grid_init.Application.Common.Interfaces;
using zeitag_grid_init.Domain.Entities;

namespace zeitag_grid_init.Application.TimeTrackings.Commands.UpdateTimeTracking;

public record UpdateTimeTrackingCommand : IRequest
{
    public int Id { get; init; }

    public DateTime RecordStart { get; set; }
    public DateTime RecordEnd { get; set; }
    public string? ShortDescription { get; set; }
    public int Type { get; set; }
}

public class UpdateTimeTrackingCommandHandler : IRequestHandler<UpdateTimeTrackingCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTimeTrackingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateTimeTrackingCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TimeTracking
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TimeTracking), request.Id);
        }

        entity.RecordStart = request.RecordStart;
        entity.RecordEnd = request.RecordEnd;
        entity.ShortDescription = request.ShortDescription;
        entity.Type = request.Type;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
