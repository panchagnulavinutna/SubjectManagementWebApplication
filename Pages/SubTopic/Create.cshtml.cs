using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SubjectManagementWebApplication.Data;
using SubjectManagementWebApplication.Models;
using SubjectManagementWebApplication.Models.Subjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }
    [BindProperty]
    public SubTopic SubTopic { get; set; } = new SubTopic();

    public List<SelectListItem> TopicsList { get; set; } = new List<SelectListItem>();

    public async Task<IActionResult> OnGetAsync()
    {
        // Load topics for the dropdown
        TopicsList = await _context.Topics
            .Select(t => new SelectListItem { Value = t.TopicID.ToString(), Text = t.TopicName })
            .ToListAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            // Reload dropdown if form submission fails
            TopicsList = await _context.Topics
                .Select(t => new SelectListItem { Value = t.TopicID.ToString(), Text = t.TopicName })
                .ToListAsync();
            return Page();
        }

        // Ensure TopicID is properly assigned
        var topic = await _context.Topics.FindAsync(SubTopic.TopicID);
        if (topic == null)
        {
            ModelState.AddModelError("", "Selected Topic does not exist.");
            return Page();
        }

        SubTopic.Topic = topic; // Link subtopic to selected topic
        _context.SubTopics.Add(SubTopic);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
