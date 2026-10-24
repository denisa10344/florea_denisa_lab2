using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using florea_denisa_lab2.Models;

namespace florea_denisa_lab2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly florea_denisa_lab2Context _context;

    public IndexModel(florea_denisa_lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Book = await _context.Book
     .Include(b => b.Author)
     .Include(b => b.Publisher)
     .ToListAsync();
    }
}
