namespace Bloggie.Data
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }
        public string Slug { get; set; }

        public List<Post> Posts { get; set; }
    }
}
