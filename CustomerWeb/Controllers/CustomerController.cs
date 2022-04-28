using CustomerData.Models;
using CustomerData.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            var customers = _customerRepository.FindAll();
            return View(customers);
        }
        public IActionResult Details(int id)
        {
            ViewData["Customer"] = _customerRepository.FindByPrimaryKey(id);
            return View();
        }
        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            var customer = _customerRepository.FindByPrimaryKey(id);
            return View("Form", customer);
        }
        public IActionResult Create()
        {
            ViewData["Action"] = "Create";
            return View("Form", new Customer());
        }
        public IActionResult Save(string action, Customer customer)
        {
            ViewData["Action"] = action;
            if (ModelState.IsValid)
            {
                if (action.ToString().ToLower().Equals("create"))
                {
                    _customerRepository.Insert(customer);
                }
                else if (action.ToString().ToLower().Equals("edit"))
                {
                    _customerRepository.Update(customer);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", customer);
            }
        }
    }
}
