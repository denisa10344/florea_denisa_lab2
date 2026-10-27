using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using florea_denisa_lab2.Models;
using florea_denisa_lab2.ViewModels;

namespace florea_denisa_lab2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly florea_denisa_lab2Context _context;

    public IndexModel(florea_denisa_lab2Context context)
    {
        _context = context;
    }

    public IList<Category> Category { get; set; } = default!;

    public CategoryIndexData CategoryData { get; set; }
    public int CategoryID { get; set; }
    public int BookID { get; set; }

    public async Task OnGetAsync(int? id, int? bookID)
    {
        CategoryData = new CategoryIndexData();
        CategoryData.Categories = await _context.Category
            .Include(i => i.BookCategories)
                .ThenInclude(i => i.Book)
                    .ThenInclude(i => i.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();

        if (id != null)
        {
            CategoryID = id.Value;
            Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
            CategoryData.BookCategories = category.BookCategories;
        }
    }
}