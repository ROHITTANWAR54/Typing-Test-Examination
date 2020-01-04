using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TypingTestExamination.Models
{
    public class Admin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        internal int Any()
        {
            throw new NotImplementedException();
        }
        /*
public Admin()
{
   Email = "mlsu@gmail.com";
   Password = "12345";
}
*/
    }
}
