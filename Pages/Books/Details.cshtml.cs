using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using florea_denisa_lab2.Models;

namespace florea_denisa_lab2.Pages.BookPages;

public class DetailsModel : PageModel
{
    private readonly florea_denisa_lab2Context _context;

    public DetailsModel(florea_denisa_lab2Context context)
    {
        _context = context;
    }

    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Book
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories).ThenInclude(b => b.Category)
            .FirstOrDefaultAsync(m => m.ID == id);

        if (book == null)
        {
            return NotFound();
        }

        Book = book;
        return Page();
    }
}