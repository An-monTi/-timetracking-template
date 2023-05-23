using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using zeitag_grid_init.Application.Common.Interfaces;
using zeitag_grid_init.Application.Common.Mappings;
using zeitag_grid_init.Application.Common.Models;
using zeitag_grid_init.Domain.Entities;

namespace zeitag_grid_init.Application.TimeTrackings.Queries.GetTimeTracking;

//Der Gedanke ist dass nach einem Tag abgefragt wird. Um alle Zeiten dieses Tages anzuzeigen.
public record GetTimeTrackingFromDate : IRequest<PaginatedList<TimeTrackingDto>>
{
    public DateTime Date { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTimeTrackingFromDateHandler : IRequestHandler<GetTimeTrackingFromDate, PaginatedList<TimeTrackingDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTimeTrackingFromDateHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TimeTrackingDto>> Handle(GetTimeTrackingFromDate request, CancellationToken cancellationToken)
    {
        return await _context.TimeTracking
            .Where(x => x.RecordStart > request.Date && x.RecordStart < request.Date.AddDays(1) )
            .OrderBy(x => x.RecordStart)
            .ProjectTo<TimeTrackingDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}