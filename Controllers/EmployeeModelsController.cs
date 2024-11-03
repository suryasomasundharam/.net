using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using newproject2.EmployeeDBContext;
using newproject2.Models;
using X.PagedList;


namespace newproject2.Controllers
{
    public class EmployeeModelsController : Controller
    {
        private readonly EmployeeDetailsDBContext _context;

        public EmployeeModelsController(EmployeeDetailsDBContext context)
        {
            _context = context;
        }
        static bool order = true;
        // GET: EmployeeModels
        public async Task<IActionResult> Index(string id = "", int? page =1, string searchString="")
        {
           
            int pageSize = 2;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<EmployeeModel> employeeDetailsDBContext = null;
              employeeDetailsDBContext = _context.Employeedb.Include(e => e.Projects).Select(s=>s).ToPagedList(pageIndex, pageSize);
           // IPagedList<EmployeeModel>  employeeDetail = from s in _context.Employeedb.select(s => s);
            if (!String.IsNullOrEmpty(searchString))
            {
                employeeDetailsDBContext = employeeDetailsDBContext.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString)).ToPagedList(pageIndex, pageSize);
            }
            //var employeeDetailsDBContext = _context.Employeedb.Include(e => e.Projects);
            switch (id) {
                case "":
                    break;
                case "1":
                    //employeeDetailsDBContext = from n in _context.Employeedb!.Include(e => e.Projects)
                    //                           orderby n.FirstName ascending
                    //                           select n;
                    if (order)
                    {
                        employeeDetailsDBContext = employeeDetailsDBContext.OrderBy(n => n.FirstName).ToPagedList(pageIndex, pageSize);
                        order = false;
                    }
                    else
                    {
                        employeeDetailsDBContext = employeeDetailsDBContext.OrderByDescending(n => n.FirstName).ToPagedList(pageIndex, pageSize);
                        order = true;
                    }
                    break;
                case "2":
                    //employeeDetailsDBContext = from n in _context.Employeedb!.Include(e => e.Projects)
                    //                           orderby n.FirstName ascending
                    //                           select n;
                    employeeDetailsDBContext = employeeDetailsDBContext.OrderBy(n => n.Salary).ToPagedList(pageIndex, pageSize);

                    //return View(await employeeDetailsDBContext.OrderByDescending(n => n.Salary).ToListAsync());
                    break;
                case "3":
                    employeeDetailsDBContext = employeeDetailsDBContext.OrderBy(n => n.Role).ToPagedList(pageIndex, pageSize);
                    break;
                default:
                    Console.WriteLine("working");
                    break;
            }
          /*  var viewModel = new Page
            {
                  PageCount = 10,
                 PageNumber = 5
          }*/;
/*
      return Page();*/
           /* int pageSize = 2;
            int pageNumber = (page ?? 1);*/
            /* @(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber) of @Model.PageCount
             ViewBag["PageNumber"] = pageNumber;
             ViewBag["PageCount"] = pageSize;*/
          

            return View((PagedList<EmployeeModel>)employeeDetailsDBContext);
        }

        // GET: EmployeeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employeedb == null)
            {
                return NotFound();
            }

            IQueryable<EmployeeModel> employeeModel = _context.Employeedb.Include(e => e.Projects).Select(s => s);
            

            if (employeeModel == null)
            {
                return NotFound();
            }

            return View(await employeeModel.FirstOrDefaultAsync(m => m.Id == id));
        }
        public async Task<IActionResult> Salary(int? id)
        {
            if (id == null || _context.Employeedb == null)
            {
                return NotFound();
            }

            // var employeeModel =  _context.Employeedb n Where(n => n.id == id).Select(n => n.Salary);
            // Option 1: To get a single salary value
            /*     var SalaryModel = _context.Employeedb.Where(n => n.Id == id).Select(n => n.Salary).SingleOrDefault();*/
            IQueryable<EmployeeModel> salary = _context.Employeedb.Where(n => n.Id == id);
             ViewBag.salary=salary.Select(n => n.Salary).SingleOrDefault();
            // Option 2: To get a collection of salaries
            /*IEnumerable<decimal> salaries = _context.Employees.Where(n => n.id == id).Select(n => n.Salary).ToList();

            // Option 3: To get a collection of Employee objects with the desired properties
            IEnumerable<Employee> employees = _context.Employees.Where(n => n.id == id).Select(n => new Employee { Id = n.Id, Salary = n.Salary }).ToList();*/
            if (salary == null)
            {
                return NotFound();
            }

            return View();
        }

        // GET: EmployeeModels/Create
        public IActionResult Create()
        {
           
            ViewData["Project_id"] = new SelectList(_context.Project, "Id", "Projectname");
            return View();
        }
        //public async Task<IActionResult> Index(string id)
        //{

        //    var employeeDetailsDBContext =  from n in _context.Employeedb!.Include(e => e.Projects)
        //               orderby n.FirstName ascending
        //               select n;

        //    return View(await employeeDetailsDBContext.ToListAsync());


          
        //}
        //public IActionResult Create()
        //{

        //    ViewData["Project_id"] = new SelectList(_context.Project, "Id", "Projectname");
        //    return View();
        //}

        // POST: EmployeeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Mobile,Role,joining_date,Salary,Project_id,Address")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Project_id"] = new SelectList(_context.Project, "Id", "Id", employeeModel.Project_id);
            return View(employeeModel);
        }

        /*  // GET: EmployeeModels/Edit/5        
          public  IActionResult  Edit(int? id)
          {
              if (id == null || _context.Employeedb == null)
              {
                  return NotFound();
              }

              var employeeModel =  _context.Employeedb.FindAsync(id);
              if (employeeModel == null)
              {
                  return NotFound();
              }
              ViewData["Project_id"] = new SelectList(_context.Project, "Id", "Id", employeeModel.T;
              return PartialView("Edit",employeeModel);
          }*/

        // GET: EmployeeModels/Edit/5        
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Employeedb == null)
            {
                return NotFound();
            }

            var employeeModel = _context.Employeedb.Where(p=>p.Id == id).FirstOrDefault();
            if (employeeModel == null)
            {
                return NotFound();
            }
            ViewData["Project_id"] = new SelectList(_context.Project, "Id", "Id", employeeModel.Project_id);
            ViewData["Project_id"] = new SelectList(_context.Project, "Id", "Id", employeeModel.Project_id);
           return PartialView("Edit", employeeModel);
        }

        /* public JsonResult Edit(int? id)
         {
            *//* if (id == null || _context.Employeedb == null)
             {
                 return NotFound();
             }*//*

             var employeeModel = _context.Employeedb.Find(id);
            *//* if (employeeModel == null)
             {
                 return NotFound();
             }*//*
             ViewData["Project_id"] = new SelectList(_context.Project, "Id", "Id", employeeModel.Project_id);
             return Json(employeeModel);
         }*/

        // POST: EmployeeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Mobile,Role,joining_date,Salary,Project_id,Address")] EmployeeModel employeeModel)
        {
            if (id != employeeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeModelExists(employeeModel.Id))
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
            ViewData["Project_id"] = new SelectList(_context.Project, "Id", "Id", employeeModel.Project_id);
            return View(employeeModel);
        }
        /*[HttpPost]
         [ValidateAntiForgeryToken]
         public JsonResult Edit(int id, [Bind("Id,FirstName,LastName,Email,Mobile,Role,joining_date,Salary,Project_id,Address")] EmployeeModel employeeModel)
         {
            *//* if (id != employeeModel.Id)
             {
                 return NotFound();
             }
*//*
             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(employeeModel);
                      _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                    *//* if (!EmployeeModelExists(employeeModel.Id))
                     {
                         return NotFound();
                     *//*}*//*
                     else
                     {
                         throw;
                     }*//*
                 }
                 return (Json("updated"));
             }
             ViewData["Project_id"] = new SelectList(_context.Project, "Id", "Id", employeeModel.Project_id);
             return Json(employeeModel);
         }*/
        // GET: EmployeeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employeedb == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.Employeedb
                .Include(e => e.Projects)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return View(employeeModel);
        }

        // POST: EmployeeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employeedb == null)
            {
                return Problem("Entity set 'EmployeeDetailsDBContext.Employeedb'  is null.");
            }
            var employeeModel = await _context.Employeedb.FindAsync(id);
            if (employeeModel != null)
            {
                _context.Employeedb.Remove(employeeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        private bool EmployeeModelExists(int id)
        {
          return (_context.Employeedb?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
