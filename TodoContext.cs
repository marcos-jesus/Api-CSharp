using Microsoft.EntityFrameworkCore;
using api_CSharp;
namespace api_CSharp.Models;

public class TodoContext: DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options): base(options)
    {

    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;

    public DbSet<api_CSharp.AddFolk> AddFolk { get; set; } = default!;
}
