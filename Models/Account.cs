using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TypingTestExamination.Models
{
    public class Account
    {
        [Key]
        public int Rollno
        {
            get;
            set;
        }

        [Required]
        public string Name
        {
            get;
            set;
        }
        [Required]
        public string Father
        {
            get;
            set;
        }

        [Required]
        [EmailAddress]
        public string Email
        {
            get;
            set;
        }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})")]
        public string Password
        {
            get;
            set;
        }

        [Required]
        public DateTime Birth
        {
            get;
            set;
        }


        [Required]
        public string Gender
        {
            get;
            set;
        }
    }
}
