using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SubjectManagementWebApplication.Data;
using SubjectManagementWebApplication.Models;
using SubjectManagementWebApplication.Models.Subjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Topic> Topics { get; set; } = new List<Topic>();

    public async Task OnGetAsync()
    {
        // Load topics with their subtopics
        Topics = await _context.Topics.Include(t => t.SubTopics).ToListAsync();
    }
}
