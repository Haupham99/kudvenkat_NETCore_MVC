using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Mời nhập tên đăng nhập !")]
        
        
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Địa chỉ email không hợp lệ !")]
        [Display(AutoGenerateField = false, Name = "Địa chỉ Email")]
        public string Email { get; set; }
        //[Required]
        public Dept? Department { get; set; }
    }
}
