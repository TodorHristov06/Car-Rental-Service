using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarPal.Data;
using CarPal.Models;
using AutoMapper;
using CarPal.Services;
using CarPal.ViewModels;

namespace CarPal.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllAsync();
            var customerViewModels = _mapper.Map<IEnumerable<CustomerViewModel>>(customers);
            return View(customerViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(customerViewModel);
                await _customerService.AddAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customerViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
            return View(customerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerViewModel customerViewModel)
        {
            if (id != customerViewModel.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(customerViewModel);
                await _customerService.UpdateAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customerViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
            return View(customerViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
