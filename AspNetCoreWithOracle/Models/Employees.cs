using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithOracle.Models
{
    public class Employees
    {
        [Required]
        public int employee_id
        {
            get;
            set;
        }
        public string first_name
        {
            get;
            set;
        }
        
        [Required]
        public string last_name
        {
            get;
            set;
        }

        [Required]
        public string email
        {
            get;
            set;
        }

        [Required]
        public string job_id
        {
            get;
            set;
        }

        [Required]
        [DataType(DataType.Date)]
        public DateTime hire_date
        {
            get;
            set;
        }
    }
}
