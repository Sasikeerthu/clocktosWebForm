using clocktosWebForm.Data;
using clocktosWebForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace clocktosWebForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly clocktosWebFormDBContext _context;

        public HomeController(clocktosWebFormDBContext context)
        {
            _context = context;
        }

         // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }
        // GET: Employee
        public async Task<IActionResult> EmployeeStorage()
        {

            return View(await _context.Employees.ToListAsync());
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Emp_Name,Emp_Mail,Gender,Experience,Emp_Ctc,Net_Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(EmployeeStorage));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Emp_Name,Emp_Mail,Gender,Experience,Emp_Ctc,Net_Salary")] Employee employee)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    var existingEmployee = await _context.Employees.FindAsync(id);
                    if (existingEmployee == null)
                    {
                        return NotFound();
                    }

                    // Update the existing employee's properties with the incoming model's properties
                    existingEmployee.Emp_Name = employee.Emp_Name;
                    existingEmployee.Emp_Mail = employee.Emp_Mail;
                    existingEmployee.Gender = employee.Gender;
                    existingEmployee.Experience = employee.Experience;
                    existingEmployee.Emp_Ctc = employee.Emp_Ctc;
                    existingEmployee.Net_Salary = employee.Net_Salary;

                    // Mark the entity as modified
                    _context.Entry(existingEmployee).State = EntityState.Modified;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(EmployeeStorage));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Emp_No == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EmployeeStorage));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Emp_No == id);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
