using EduManage.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EduManage.Controllers;

public class Registration:Controller
{
    private readonly DataContext _context;
    public Registration(DataContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var reg = await _context.Registries.Include(x => x.Student).Include(x => x.Course).ToListAsync();
        return View(reg);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Students = new SelectList(await _context.Students.ToListAsync(), "StudentId", "NameSurname");
        ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId", "Title");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Registry model)
    {
        model.RegistryDate = DateTime.Now;
        _context.Registries.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
}