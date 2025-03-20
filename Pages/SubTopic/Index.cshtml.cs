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
    public class IndexModel : PageModel
    {
        private readonly SubjectManagementWebApplication.Data.SubjectManagementWebApplicationContext _context;

        public IndexModel(SubjectManagementWebApplication.Data.SubjectManagementWebApplicationContext context)
        {
            _context = context;
        }

        public IList<SubTopics> SubTopics { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SubTopics = await _context.SubTopics
                .Include(s => s.Topic).ToListAsync();
        }
    }
}
