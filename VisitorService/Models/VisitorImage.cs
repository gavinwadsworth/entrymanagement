using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisitorService.Models
{
    public class VisitorImage
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string ImagePath { get; set; }
    }
}
