using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SubjectManagementWebApplication.Data;

namespace SubjectManagementWebApplication.Models.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly SubjectManagementWebApplication.Data.SubjectContext _context;

        public IndexModel(SubjectManagementWebApplication.Data.SubjectContext context)
        {
            _context = context;
        }

        public IList<Topics> Topics { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Topics = await _context.Topics.ToListAsync();
        }
    }
}
