using System.ComponentModel.DataAnnotations;
using TH_CNPMNC.Enum;

namespace TH_CNPMNC.Models
{
    public class Student
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public Gender gender { get; set; }
        [Required]
        public int faculty_id {get;set;}
        public Faculty Faculty {get;set;}
    }
}