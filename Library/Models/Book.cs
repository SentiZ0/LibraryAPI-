using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(75)]
        [Required(ErrorMessage = "Title is needed")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is needed")]
        [MaxLength(50)]
        public string Author { get; set; }

        [MaxLength(300)]
        [Required(ErrorMessage = "Description is needed")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Missing value")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
    }
}
