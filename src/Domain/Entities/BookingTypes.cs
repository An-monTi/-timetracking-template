namespace zeitag_grid_init.Domain.Entities;

public class BookingTypes
{
    public int Id { get; set; }
    public int BookingTypeID { get; set; }
    public required string Description { get; set; }
}
