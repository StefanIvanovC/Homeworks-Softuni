using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        public int HomeworkId { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Content { get; set; }

        public ContentType ContentType { get; set; }
    }
}
//  o	HomeworkId
// o Content(string, linking to a file, not unicode)
// o ContentType(enum – can be Application, Pdf or Zip)
// o SubmissionTime
// o	StudentId
// o	CourseId
