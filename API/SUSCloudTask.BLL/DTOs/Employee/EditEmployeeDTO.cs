using System.ComponentModel.DataAnnotations;

namespace SUSCloudTask.BLL.DTOs.Employee
{
    public class EditEmployeeDTO
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public string Salary { get; set; }

        [Required(ErrorMessage = "Project is required")]
        public string Project { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }
    }
}
