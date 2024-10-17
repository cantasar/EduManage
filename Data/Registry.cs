using System.ComponentModel.DataAnnotations;

namespace EduManage.Data;

public class Registry
{
    [Key]
    public int RegistryId { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
    public DateTime RegistryDate { get; set; }
}