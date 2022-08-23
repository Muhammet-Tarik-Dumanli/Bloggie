using Bloggie.Helpers;

namespace Bloggie.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is Category)
                {
                    Category cat = (Category)item.Entity;
                    cat.Slug = UrlUtilities.URLFriendly(cat.Name);
                }

                if (item.Entity is Post)
                {
                    var post = (Post)item.Entity;
                    post.Slug = UrlUtilities.URLFriendly(post.Title);
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}