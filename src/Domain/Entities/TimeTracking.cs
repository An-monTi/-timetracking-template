
using System.ComponentModel.DataAnnotations.Schema;

namespace zeitag_grid_init.Domain.Entities;

//Schritt 1 erstellen des Models
public class TimeTracking
{
    public int Id { get; set; }
    public DateTime RecordStart { get; set; }
    public DateTime RecordEnd { get; set; }
    public string? ShortDescription { get; set; }
    //Foreign key BookingType
    public int Type { get; set; }


}
