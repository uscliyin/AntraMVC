using AntraMVC.Data;
using AntraMVC.Models.Domain;
using AntraMVC.Repository;
using AntraMVC.Service;
using Microsoft.AspNetCore.Mvc;

namespace AntraMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeSerivce;
        public EmployeeController(IEmployeeService employeeSerivce)
        {
            _employeeSerivce = employeeSerivce;
        }
        public async Task<IActionResult> Index()
        {
            var employeeLists = await _employeeSerivce.GetAllEmployees();
            return View(employeeLists);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                await _employeeSerivce.AddOneEmployee(obj);
                TempData["success"] = "Created Employee Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["success"] = "Created Employee Unsuccessfully";
                return View();
            }
            
        }
        public async Task<IActionResult> Edit(int id)
        {
            var employeeObj=await _employeeSerivce.GetOneEmployee(id);
            return View(employeeObj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                await _employeeSerivce.UpdateEmployee(obj);
                TempData["success"]= "Updated Employee successfully";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["success"] = "Updated Employee Unsuccessfully";
                return RedirectToAction("Index");
                
            }
                
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _employeeSerivce.DeleteOneEmployee(id);
            TempData["success"] = "Deleted Employee Successfully";
            return RedirectToAction("Index");
            
        }
    }
}
