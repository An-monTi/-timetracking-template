using zeitag_grid_init.Domain.Entities;
using zeitag_grid_init.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace zeitag_grid_init.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole("Administrator");

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        // Default data
        // Seed, if necessary
        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
            });

            await _context.SaveChangesAsync();
        }

        //Data Für BookingTypes
        if (!_context.BookingTypes.Any())
        {
            _context.BookingTypes.Add(new BookingTypes { BookingTypeID = 0, Description = "Präsenzzeit" });
            _context.BookingTypes.Add(new BookingTypes { BookingTypeID = 1, Description = "Pause" });
            _context.BookingTypes.Add(new BookingTypes { BookingTypeID = 2, Description = "Krankheit oder Unfall" });
            _context.BookingTypes.Add(new BookingTypes { BookingTypeID = 3, Description = "bezahlte Absenz" });
            _context.BookingTypes.Add(new BookingTypes { BookingTypeID = 4, Description = "unbezahlte Absenz" });


            await _context.SaveChangesAsync();
        }

        //Data für TimeTracking
        if (!_context.TimeTracking.Any())
        {
            _context.TimeTracking.Add(new TimeTracking
            {
                RecordStart = DateTime.Parse("15.03.2023 9:00"),
                RecordEnd = DateTime.Parse("15.03.2023 9:15"),
                ShortDescription = "Stand Up",
                Type = 0
            });
            _context.TimeTracking.Add(new TimeTracking
            {
                RecordStart = DateTime.Parse("15.03.2023 9:15"),
                RecordEnd = DateTime.Parse("15.03.2023 10:00"),
                ShortDescription = "Kurs",
                Type = 3
            });
            _context.TimeTracking.Add(new TimeTracking
            {
                RecordStart = DateTime.Parse("15.03.2023 10:00"),
                RecordEnd = DateTime.Parse("15.03.2023 10:10"),
                ShortDescription = "",
                Type = 1
            });
            _context.TimeTracking.Add(new TimeTracking
            {
                RecordStart = DateTime.Parse("15.03.2023 10:10"),
                RecordEnd = DateTime.Parse("15.03.2023 12:00"),
                ShortDescription = "Projekt Zeiterfassung 2.0",
                Type = 0
            });
            _context.TimeTracking.Add(new TimeTracking
            {
                RecordStart = DateTime.Parse("15.03.2023 12:00"),
                RecordEnd = DateTime.Parse("15.03.2023 12:30"),
                ShortDescription = "",
                Type = 1
            });
            _context.TimeTracking.Add(new TimeTracking
            {
                RecordStart = DateTime.Parse("15.03.2023 12:30"),
                RecordEnd = DateTime.Parse("15.03.2023 17:00"),
                ShortDescription = "Kompensation",
                Type = 4
            });
        }
    }
}
