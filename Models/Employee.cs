using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clocktosWebForm.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Emp_No { get; set; }

        [Required(ErrorMessage = "Employee Name is required.")]
        [StringLength(100, ErrorMessage = "Employee Name cannot be longer than 100 characters.")]
        public string Emp_Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Emp_Mail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Experience is required.")]
        [Range(0, 50, ErrorMessage = "Experience must be between 0 and 50 years.")]
        public int Experience { get; set; } 

        [Required(ErrorMessage = "Employee CTC is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Employee CTC must be a positive number.")]
        public string Emp_Ctc { get; set; } = string.Empty;

        [Required(ErrorMessage = "Net Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Net Salary must be a positive number.")]
        public string Net_Salary { get; set; } = string.Empty;
    }
}
