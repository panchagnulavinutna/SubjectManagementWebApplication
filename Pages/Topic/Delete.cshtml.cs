using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SubjectManagementWebApplication.Data;
using SubjectManagementWebApplication.Models.Subjects;

namespace SubjectManagementWebApplication.Pages.SubTopic
{
    public class DeleteModel : PageModel
    {
        private readonly SubjectManagementWebApplication.Data.SubjectManagementWebApplicationContext _context;

        public DeleteModel(SubjectManagementWebApplication.Data.SubjectManagementWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Topics Topics { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topics = await _context.Topics.FirstOrDefaultAsync(m => m.TopicID == id);

            if (topics == null)
            {
                return NotFound();
            }
            else
            {
                Topics = topics;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topics = await _context.Topics.FindAsync(id);
            if (topics != null)
            {
                Topics = topics;
                _context.Topics.Remove(Topics);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
