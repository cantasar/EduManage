using System.ComponentModel.DataAnnotations;

namespace EduManage.Data;

public class Student
{
    [Key]
    public int StudentId { get; set; }
    
    public string? Name { get; set; }
    public string? Surname { get; set; }
    
    public string? NameSurname { get => Name is null ? null : Name + " " + Surname; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    
    public ICollection<Registry> RegCourses { get; set; } = new List<Registry>();
}