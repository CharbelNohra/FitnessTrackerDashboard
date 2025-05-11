using FitnessTrackerDashboard.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class DashboardModel : PageModel
{
    private readonly FitnessEntryService _entryService;

    public DashboardModel(FitnessEntryService entryService)
    {
        _entryService = entryService;
    }

    public List<FitnessEntry> Entries { get; set; } = new();
    [BindProperty] public FitnessEntry NewEntry { get; set; }
    public bool ShowModal { get; set; }

    public IActionResult OnGet()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
            return RedirectToPage("/Login");

        Entries = _entryService.GetEntriesByUserId(userId.Value);
        ShowModal = !_entryService.HasEntryThisWeek(userId.Value);
        return Page();
    }

    public IActionResult OnPost()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
            return RedirectToPage("/Login");

        NewEntry.UserId = userId.Value;
        NewEntry.Date = DateTime.Now;
        _entryService.AddEntry(NewEntry);

        return RedirectToPage();
    }
}
