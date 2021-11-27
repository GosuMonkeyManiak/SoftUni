using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [Required]
        [MinLength(GlobalConstants.Employee_Username_Min_Length)]
        [MaxLength(GlobalConstants.Employee_Username_Max_Length)]
        [RegularExpression(GlobalConstants.Employee_Username_Regex)]
        public string Username { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(GlobalConstants.Employee_Phone_Max_Length)]
        [RegularExpression(GlobalConstants.Employee_Phone_Regex)]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}
