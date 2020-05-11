﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateNiteBackEndCapstone.Data;
using DateNiteBackEndCapstone.Models;
using DateNiteBackEndCapstone.Models.BusinessViewModals;
using DateNiteBackEndCapstone.Models.DateViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DateNiteBackEndCapstone.Controllers
{
    public class DatesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DatesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: Dates
        public async Task<ActionResult> Index()
        {
            var viewModel = new BusinessListViewModel();

            var user = await GetUserAsync();
            var date = await _context.Dates.FirstOrDefaultAsync(d => d.IsScheduled == false && d.UserId == user.Id);

            var businesses = await _context.Businesses.Where(b => b.DateId == date.Id).ToListAsync();

            viewModel.Date = date;
            viewModel.Businesses = businesses;

            return View(viewModel);
        }

        public async Task<ActionResult> CompleteDate(int DateId)
        {
            var user = await GetUserAsync();

            var a = DateTime.UtcNow;
            var b = new DateTime(a.Year, a.Month, a.Day, a.Hour, a.Minute, 0, DateTimeKind.Utc);

            var date = await _context.Dates.FirstOrDefaultAsync(d => d.Id == DateId);

            date.DateTime = b;
            date.IsScheduled = true;

            _context.Dates.Update(date);

            var newDate = new Date()
            {
                UserId = user.Id
            };

            _context.Dates.Add(newDate);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        // GET: Dates/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<ActionResult> ScheduledDates()
        { 
            var listViewModel = new ListOfDatesViewModel();

            var user = await GetUserAsync();
            var listOfDates = await _context.Dates.Where(d => d.IsScheduled == true && d.UserId == user.Id).ToListAsync();

            foreach (var date in listOfDates)
            {
                var viewModel = new ViewDateViewModel()
                {
                    Date = date,
                    Businesses = await _context.Businesses
                        .Where(b => b.UserId == user.Id && b.DateId == date.Id).ToListAsync()
                };

                listViewModel.ListOfDates.Add(viewModel);

            }

            return View(listViewModel);
        }


        // GET: Dates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dates/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var date = await _context.Dates.FirstOrDefaultAsync(d => d.Id == id);
            var user = await GetUserAsync();

            var viewModel = new BusinessListViewModel()
            {
                DateTime = date.DateTime
            };

            if (date.UserId != user.Id)
            {
                return NotFound();
            };

            return View(viewModel);
        }

        // POST: Dates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, BusinessListViewModel businessListViewModel)
        {
            try
            {
                var date = await _context.Dates.FirstOrDefaultAsync(d => d.Id == id);

                date.DateTime = businessListViewModel.DateTime;

                _context.Dates.Update(date);
                await _context.SaveChangesAsync();

                return RedirectToAction("ScheduledDates", "Dates");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dates/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dates/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<ApplicationUser> GetUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}