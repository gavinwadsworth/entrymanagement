using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.DTOs
{
    public class EmployeeUpdateDTO
    {
        [Required]
        public string Title { get; set; }
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
        public string PhoneNumber { get; set; }
        [Required]
        public bool FormTutor { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string AccessibilityRequirements { get; set; }
        public DateTime DBSExpiry { get; set; }
    }
}
