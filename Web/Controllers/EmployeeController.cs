using Application.Common.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ActionResult Index()
        {
            var emp = _employeeRepository.GetAllEmployees();
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
        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeRepository.CreateEmployee(emp);
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
            var obj = _employeeRepository.GetEmployeeById(Id);
            Employee emp = obj.ElementAtOrDefault(0);
            return View(emp);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Employee emp)
        {
            try
            {
                if (ModelState.IsValid && emp.Id != 0)
                {
                    _employeeRepository.UpdateEmployee(emp);
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
            var obj = _employeeRepository.GetEmployeeById(Id);
            Employee emp = obj.ElementAtOrDefault(0);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee emp)
        {
            try
            {
                _employeeRepository.DeleteEmployee(emp);
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
