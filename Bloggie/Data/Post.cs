namespace Bloggie.Data
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string AuthorId { get; set; }
        public int CategoryId { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required, MaxLength(200)]
        public string Slug { get; set; }
        public string Content { get; set; }
        public bool IsDraft { get; set; } = false;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime ModifiedTime { get; set; } = DateTime.Now;

        public Category Category { get; set; }

        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }
    }
}
