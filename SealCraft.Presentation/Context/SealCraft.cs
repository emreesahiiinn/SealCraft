using Microsoft.EntityFrameworkCore;
using SealCraft.Presentation.Models;

namespace SealCraft.Presentation.Context;

public class SealCraftDbContext(DbContextOptions<SealCraftDbContext> options) : DbContext(options)
{
    public virtual DbSet<SecretCraftFirstModel> SecretCraftFirstModels { get; set; }
}