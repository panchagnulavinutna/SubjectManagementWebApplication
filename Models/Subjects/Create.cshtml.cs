using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SubjectManagementWebApplication.Data;

namespace SubjectManagementWebApplication.Models.Subjects
{
    public class CreateModel : PageModel
    {
        private readonly SubjectManagementWebApplication.Data.SubjectContext _context;

        public CreateModel(SubjectManagementWebApplication.Data.SubjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Topics Topics { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Topics.Add(Topics);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
