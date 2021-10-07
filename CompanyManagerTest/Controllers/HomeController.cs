using CompanyManagerTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CompanyManagerTest.DbContexts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagerTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext context;

        public HomeController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Companies()
        {
            return View(await context.Companies.Include(x=>x.Employee).ToListAsync());
        }

        public IActionResult CreateCompany()
        {   
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(Company company)
        {
            await context.Companies.AddAsync(company);
            await context.SaveChangesAsync();

            return RedirectToAction("Companies");
        }

        public async Task<IActionResult> DetailsCompany(int? id)
        {
            if (id != null)
            {
                var company = await context.Companies.FirstOrDefaultAsync(p => p.Id == id);
                if (company != null)
                {
                    return View(company);
                }
                    
            }
            return NotFound();
        }

        public async Task<IActionResult> EditCompany(int? id)
        {
            if (id != null)
            {
                var company = await context.Companies.FirstOrDefaultAsync(p => p.Id == id);
                if (company != null)
                {
                    return View(company);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditCompany(Company company)
        {
            context.Companies.Update(company);
            await context.SaveChangesAsync();

            return RedirectToAction("Companies");
        }

        [HttpGet]
        [ActionName("DeleteCompany")]
        public async Task<IActionResult> ConfirmDeleteCompany(int? id)
        {
            if (id != null)
            {
                var company = await context.Companies.FirstOrDefaultAsync(p => p.Id == id);

                if (company != null)
                {
                    return View(company);
                }  
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCompany(int? id)
        {
            if (id != null)
            {
                var company = await context.Companies.FirstOrDefaultAsync(p => p.Id == id);

                if (company != null)
                {
                    context.Companies.Remove(company);
                    await context.SaveChangesAsync();

                    return RedirectToAction("Companies");
                }
            }

            return NotFound();
        }
       
        public async Task<IActionResult> Employees()
        {
            return View(await context.Employees.Include(x => x.Company).ToListAsync());
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            return RedirectToAction("Employees");
        }

        public async Task<IActionResult> PersonDetails(int? id)
        {
            if (id != null)
            {
                var employee = await context.Employees.FirstOrDefaultAsync(p => p.Id == id);
                if (employee != null)
                {
                    return View(employee);
                }

            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PersonDetails(Employee employee)
        {
            context.Employees.Update(employee);
            await context.SaveChangesAsync();

            return RedirectToAction("Employees");
        }

        [HttpGet]
        [ActionName("DeleteWorker")]
        public async Task<IActionResult> ConfirmDeleteEmployee(int? id)
        {
            if (id != null)
            {
                var employee = await context.Employees.FirstOrDefaultAsync(p => p.Id == id);

                if (employee != null)
                {
                    return View(employee);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteWorker(int? id)
        {
            if (id != null)
            {
                var employee = await context.Employees.FirstOrDefaultAsync(p => p.Id == id);

                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    await context.SaveChangesAsync();

                    return RedirectToAction("Employees");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> EditPerson(int? id)
        {
            if (id != null)
            {
                var company = await context.Employees.FirstOrDefaultAsync(p => p.Id == id);
                if (company != null)
                {
                    return View(company);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditPerson(Employee employee)
        {
            context.Employees.Update(employee);
            await context.SaveChangesAsync();

            return RedirectToAction("Employees");
        }
    }
}