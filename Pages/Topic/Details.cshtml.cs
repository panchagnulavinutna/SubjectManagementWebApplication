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
    public class DetailsModel : PageModel
    {
        private readonly SubjectManagementWebApplication.Data.SubjectManagementWebApplicationContext _context;

        public DetailsModel(SubjectManagementWebApplication.Data.SubjectManagementWebApplicationContext context)
        {
            _context = context;
        }

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
    }
}
