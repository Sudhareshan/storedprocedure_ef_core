using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SP_EfCore.Models;

namespace SP_EfCore.Controllers
{
    public class EmployeController : Controller
    {
        private readonly EmployeDbContext _dbContext;
        public EmployeController(EmployeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var getAllEmployeInfo = _dbContext.employes.FromSqlRaw("Exec getAllEmployes").ToList();
            return View(getAllEmployeInfo);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employe em)
        {
            if (ModelState.IsValid)
            {
                var parameters = new[]
              {
                    new SqlParameter("@Name", em.Name),
                    new SqlParameter("@salary", em.Salary),

                };
                _dbContext.Database.ExecuteSqlRaw("EXEC InsertEmploye @Name, @salary", parameters);
                return RedirectToAction("Index", "Employe");
            }
            return View();
        }

        public IActionResult DeleteEmploye(int id)
        {
            if (ModelState.IsValid)
            {
                var parameter = new[]
                {
                    new SqlParameter("@id",id),
                };
                _dbContext.Database.ExecuteSqlRaw("EXEC DeleteEmploye @id", parameter);
                return RedirectToAction("Index", "Employe");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {

            var empInfo = _dbContext.employes.FirstOrDefault(s => s.EmployeId == id);
            return View(empInfo);


        }
        [HttpPost]
        public IActionResult Edit(Employe em)
        {
            if (ModelState.IsValid)
            {
                var parameters = new[]
              {
                    new SqlParameter("@id",em.EmployeId),
                    new SqlParameter("@Name", em.Name),
                    new SqlParameter("@salary", em.Salary),

                };
                _dbContext.Database.ExecuteSqlRaw("EXEC UpdateEmploye @id, @Name, @salary", parameters);
                return RedirectToAction("Index", "Employe");
            }
            return View();


        }

    }
}
