using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "Char(10)")]
        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}
// o StudentId
// o Name(up to 100 characters, unicode)
// o PhoneNumber(exactly 10 characters, not unicode, not required)
// o RegisteredOn
// o Birthday (not required)
