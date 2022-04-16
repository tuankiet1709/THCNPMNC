namespace TH_CNPMNC.Models
{
    public class Faculty
    {
        public int id { get; set; }
        public string faculty_name { get; set; }
        public List<Student> Students { get; set; }
    }
}