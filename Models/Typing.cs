using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TypingTestExamination.Models
{
    public class Typing
    {
        public int Id { get; set; }
        public string Wpm { get; set; }
        public string Error { get; set; }
        public string Accuracy { get; set; }
        public string TypingTime { get; set; }
        public string Given { get; set; }
        public string Typed1 { get; set; }


    }
}
