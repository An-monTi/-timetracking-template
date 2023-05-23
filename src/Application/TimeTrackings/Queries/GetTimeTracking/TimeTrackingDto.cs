using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeitag_grid_init.Application.Common.Mappings;
using zeitag_grid_init.Domain.Entities;

namespace zeitag_grid_init.Application.TimeTrackings.Queries.GetTimeTracking;
public class TimeTrackingDto : IMapFrom<TimeTracking>
{
    public DateTime Date { get; set; }
    public DateTime RecordStart { get; set; }
    public DateTime RecordEnd { get; set; }
    public string? ShortDescription { get; set; }
    public int Type { get; set; }

}
