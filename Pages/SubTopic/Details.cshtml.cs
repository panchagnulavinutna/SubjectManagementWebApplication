using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SubjectManagementWebApplication.Data;
using SubjectManagementWebApplication.Models.Subjects;

namespace SubjectManagementWebApplication.Pages.Topic
{
    public class DetailsModel : PageModel
    {
        private readonly SubjectManagementWebApplication.Data.SubjectManagementWebApplicationContext _context;

        public DetailsModel(SubjectManagementWebApplication.Data.SubjectManagementWebApplicationContext context)
        {
            _context = context;
        }

        public SubTopics SubTopics { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subtopics = await _context.SubTopics.FirstOrDefaultAsync(m => m.SubTopicID == id);
            if (subtopics == null)
            {
                return NotFound();
            }
            else
            {
                SubTopics = subtopics;
            }
            return Page();
        }
    }
}
