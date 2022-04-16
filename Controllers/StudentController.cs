using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TH_CNPMNC.Data;
using TH_CNPMNC.Models;
using TH_CNPMNC.Enum;

public class StudentController : Controller
{
    private readonly ApplicationDbContext _context;
    public StudentController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET: Students
    public IActionResult Index()
    {
        return View(_context.Students.Include(x => x.Faculty).ToList());
    }

    // GET: Students/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var students = _context.Students.Include(x => x.Faculty).FirstOrDefault(m => m.id == id);
        if (students == null)
        {
            return NotFound();
        }

        return View(students);
    }

    // GET: Students/Create
    public IActionResult Create()
    {
        var listFaculty = _context.Faculties.ToList();
        var Faculties = new List<SelectListItem> { };
        foreach (var item in listFaculty)
        {
            Faculties.Add(new SelectListItem { Text = item.faculty_name, Value = item.id.ToString() });
        }
        ViewBag.Faculties = Faculties;

        ViewBag.Gender = new List<SelectListItem>
    {
        new SelectListItem {Text = "Male", Value = "0"},
        new SelectListItem {Text = "Female", Value = "1"}
    };

        return View(new Student());
    }

    // POST: Students/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("id,first_name,last_name,email,gender,faculty_id,Faculty")] Student students)
    {
        ModelState.Remove("Faculty");
        if (ModelState.IsValid)
        {
            _context.Add(students);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(students);
    }

    // GET: Students/Edit/5
    public IActionResult Edit(int? id)
    {
        
        if (id == null)
        {
            return NotFound();
        }

        var students = _context.Students.Find(id);
        if (students == null)
        {
            return NotFound();
        }
        var listFaculty = _context.Faculties.ToList();
        var Faculties = new List<SelectListItem> { };
        foreach (var item in listFaculty)
        {
            Faculties.Add(new SelectListItem { Text = item.faculty_name, Value = item.id.ToString() });
        }
        ViewBag.Faculties = Faculties;

        ViewBag.Gender = new List<SelectListItem>
    {
        new SelectListItem {Text = "Male", Value = "0"},
        new SelectListItem {Text = "Female", Value = "1"}
    };
        return View(students);
    }

    // POST: Students/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("id,first_name,last_name,email,gender,faculty_id,Faculty")] Student students)
    {
        if (id != students.id)
        {
            return NotFound();
        }
        ModelState.Remove("Faculty");

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(students);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(students.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(students);
    }

    // GET: Students/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var students = _context.Students
            .Include(x => x.Faculty)
            .FirstOrDefault(m => m.id == id);
        if (students == null)
        {
            return NotFound();
        }

        return View(students);
    }

    // POST: Students/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var students = _context.Students.Find(id);
        _context.Students.Remove(students);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    private bool StudentsExists(int id)
    {
        return _context.Students.Any(e => e.id == id);
    }
}