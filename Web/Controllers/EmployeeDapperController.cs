using Application.Common.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EmployeeDapperController : Controller
    {
        private readonly IEmployeeDapperRepository _empRepo;

        public EmployeeDapperController(IEmployeeDapperRepository empRepo)
        {
            _empRepo = empRepo;
        }

        public ActionResult Index()
        {
            var emp = _empRepo.GetAllEmployees();
            return View(emp);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeDapper emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _empRepo.CreateEmployee(emp);
                    TempData["success"] = "The employee has been created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Update(int Id)
        {
            var obj = _empRepo.GetEmployeeById(Id);
            //Employee emp = obj.ElementAtOrDefault(0);
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EmployeeDapper emp)
        {
            try
            {
                if (ModelState.IsValid && emp.Id != 0)
                {
                    _empRepo.UpdateEmployee(emp);
                    TempData["success"] = "The employee has been deleted successfully.";
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int Id)
        {
            var obj = _empRepo.GetEmployeeById(Id);
            //Employee emp = obj.ElementAtOrDefault(0);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(EmployeeDapper emp)
        {
            try
            {
                _empRepo.DeleteEmployee(emp.Id);
                TempData["success"] = "The employee has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
