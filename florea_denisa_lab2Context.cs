using Microsoft.EntityFrameworkCore;

public class florea_denisa_lab2Context(DbContextOptions<florea_denisa_lab2Context> options) : DbContext(options)
{
    public DbSet<florea_denisa_lab2.Models.Book> Book { get; set; } = default!;

    public DbSet<florea_denisa_lab2.Models.Publisher> Publisher { get; set; } = default!;

    public DbSet<florea_denisa_lab2.Models.Author> Author { get; set; } = default!;
}