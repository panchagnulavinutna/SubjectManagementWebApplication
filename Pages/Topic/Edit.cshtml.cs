using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SubjectManagementWebApplication.Data;
using SubjectManagementWebApplication.Models.Subjects;

namespace SubjectManagementWebApplication.Pages.SubTopic
{
    public class EditModel : PageModel
    {
        private readonly SubjectManagementWebApplication.Data.SubjectManagementWebApplicationContext _context;

        public EditModel(SubjectManagementWebApplication.Data.SubjectManagementWebApplicationContext context)
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

            var topics =  await _context.Topics.FirstOrDefaultAsync(m => m.TopicID == id);
            if (topics == null)
            {
                return NotFound();
            }
            Topics = topics;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Topics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicsExists(Topics.TopicID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TopicsExists(int id)
        {
            return _context.Topics.Any(e => e.TopicID == id);
        }
    }
}
