using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisitorService.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(25)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(25)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string EmailAddress { get; set; }
        [Column(TypeName = "char(11)")]
        public string PhoneNumber{ get; set; }
        [Column(TypeName = "varchar(50)")]
        public string CompanyName { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string VehicleRegistration { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string AccessibilityRequirements { get; set; }

    }
}
