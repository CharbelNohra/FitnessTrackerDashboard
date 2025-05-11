using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FitnessTrackerDashboard.Services;

public class RegisterModel : PageModel
{
    private readonly UserService _userService;

    public RegisterModel(UserService userService) => _userService = userService;

    [BindProperty, Required]
    public string Username { get; set; }

    [BindProperty, Required, DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 6)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).+$", ErrorMessage = "Password must include uppercase, lowercase, and a number.")]
    public string Password { get; set; }

    [BindProperty, Required, DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        _userService.Register(Username, Password);
        return RedirectToPage("/Login");
    }
}
