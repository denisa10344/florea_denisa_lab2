using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using florea_denisa_lab2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace florea_denisa_lab2.Pages.BookPages;

public class CreateModel : PageModel
{
    private readonly florea_denisa_lab2Context _context;

    public CreateModel(florea_denisa_lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FullName");
        ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
        return Page();
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        _context.Book.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
