using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using florea_denisa_lab2.Models;

namespace florea_denisa_lab2.Pages.AuthorPages;

public class IndexModel : PageModel
{
    private readonly florea_denisa_lab2Context _context;

    public IndexModel(florea_denisa_lab2Context context)
    {
        _context = context;
    }

    public IList<Author> Author { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Author = await _context.Author.ToListAsync();
    }
}
