using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using zeitag_grid_init.Application.Common.Exceptions;
using zeitag_grid_init.Application.Common.Interfaces;
using zeitag_grid_init.Domain.Entities;
using zeitag_grid_init.Domain.Events;

namespace zeitag_grid_init.Application.TimeTrackings.Commands.DeleteTimeTracking;

public record DeleteTimeTrackingCommand(int Id) : IRequest;

public class DeleteTimeTrackingCommandHandler : IRequestHandler<DeleteTimeTrackingCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTimeTrackingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteTimeTrackingCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TimeTracking
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TimeTracking), request.Id);
        }

        _context.TimeTracking.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}