using System.ComponentModel.DataAnnotations;

namespace EduManage.Data;

public class Student
{
    [Key]
    public int StudentId { get; set; }
    
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}