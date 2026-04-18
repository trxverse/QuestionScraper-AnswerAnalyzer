
using Microsoft.EntityFrameworkCore;
using QuestionScrapper.Models;

namespace QuestionScrapper.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<QuestionPaper> QuestionPapers { get; set; } 
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionGroup> QuestionGroups {  get; set; }
}
