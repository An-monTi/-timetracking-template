using zeitag_grid_init.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace zeitag_grid_init.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
