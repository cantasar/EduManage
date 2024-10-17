using EduManage.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduManage.Controllers;

public class StudentController : Controller
{
    private readonly DataContext _context;
    public StudentController(DataContext context)
    {
        _context = context;
    }
    
    //GET
    public async Task<IActionResult> Index()
    {
        var students = await _context.Students.ToListAsync();
        return View(students);
    }
    
    // GET
    public IActionResult Create()
    {
        return View();
    }
    // POST
    [HttpPost]
    public async Task<IActionResult> Create(Student model)
    {
        _context.Students.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    } 
    
    
    // GET
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var student = await _context.Students.Include(o => o.RegCourses).ThenInclude(o => o.Course).FirstOrDefaultAsync(o => o.StudentId == id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }
    
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Student model)
    {
        if (id != model.StudentId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Students.Any(o => o.StudentId == model.StudentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }
        
        return View(model);
    } 
    
    //GET
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }
    
    
    //POST
    public async Task<IActionResult> Delete([FromForm] int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        } 
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
}