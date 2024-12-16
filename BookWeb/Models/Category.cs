using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Range(1, 100,ErrorMessage ="Between 1 - 100 range Please")]
        [DisplayName("Display Order")]
        public string DisplayOrder { get; set; }

    }
}
