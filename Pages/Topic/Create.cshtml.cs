using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SubjectManagementWebApplication.Data;
using SubjectManagementWebApplication.Models.Subjects; // ✅ Ensure this namespace contains your SubTopic class
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectManagementWebApplication.Pages.SubTopic
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Use full namespace to avoid conflicts
        [BindProperty]
        public SubjectManagementWebApplication.Models.Subjects.SubTopic SubTopic { get; set; } = new SubjectManagementWebApplication.Models.Subjects.SubTopic();

        public List<SelectListItem> TopicsList { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync()
        {
            TopicsList = await _context.Topics
                .Select(t => new SelectListItem { Value = t.TopicID.ToString(), Text = t.TopicName })
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                TopicsList = await _context.Topics
                    .Select(t => new SelectListItem { Value = t.TopicID.ToString(), Text = t.TopicName })
                    .ToListAsync();
                return Page();
            }

            _context.SubTopics.Add(SubTopic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
