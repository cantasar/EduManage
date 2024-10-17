using EduManage.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduManage.Controllers;

public class CourseController:Controller
{
    private readonly DataContext _context;
    
    public CourseController(DataContext context)
    {
        _context = context;
    }
    
    //INDEX
    public async Task<IActionResult> Index()
    {
        var courses = await _context.Courses.ToListAsync();
        return View(courses);
    }

    //ADD GET
    public IActionResult Add()
    {
        return View();
    }

    //ADD POST
    [HttpPost]
    public async Task<IActionResult> Add(Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    //DELETE GET
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            return NotFound();
        }
        return View(course);
    }
    
    //DELETE POST
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> Delete([FromForm] int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            return NotFound();
        }
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}