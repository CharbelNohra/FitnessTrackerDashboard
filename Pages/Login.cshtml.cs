using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FitnessTrackerDashboard.Services;
using FitnessTrackerDashboard.Models;

public class LoginModel : PageModel
{
    private readonly UserService _userService;

    [BindProperty] public string Username { get; set; }
    [BindProperty] public string Password { get; set; }

    public LoginModel(UserService userService)
    {
        _userService = userService;
    }

    public IActionResult OnPost()
    {
        User? user = _userService.Authenticate(Username, Password);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid credentials.");
            return Page();
        }

        HttpContext.Session.SetInt32("UserId", user.Id);
        HttpContext.Session.SetString("Username", user.Username);
        return RedirectToPage("/Dashboard");
    }
}
