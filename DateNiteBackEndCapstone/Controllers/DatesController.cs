using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateNiteBackEndCapstone.Data;
using DateNiteBackEndCapstone.Models;
using DateNiteBackEndCapstone.Models.BusinessViewModels;
using DateNiteBackEndCapstone.Models.DateViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DateNiteBackEndCapstone.Controllers
{
    [Authorize]
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

        public async Task<ActionResult> CompleteDate(int DateId, BusinessListViewModel viewModel)
        {
            var user = await GetUserAsync();

            var date = await _context.Dates.FirstOrDefaultAsync(d => d.Id == DateId);

            date.DateTime = viewModel.DateTime;
            date.IsScheduled = true;

            _context.Dates.Update(date);

            var newDate = new Date()
            {
                UserId = user.Id
            };

            _context.Dates.Add(newDate);

            await _context.SaveChangesAsync();

            return RedirectToAction("ScheduledDates", "Dates");
        }

        public async Task<ActionResult> ScheduledDates()
        {
            var listViewModel = new ListOfDatesViewModel();

            var user = await GetUserAsync();
            var listOfDates = await _context.Dates
                .OrderBy(d => d.DateTime)
                .Where(d => d.IsScheduled == true && d.UserId == user.Id && d.DateTime >= DateTime.Now).ToListAsync();

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
        private async Task<ApplicationUser> GetUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}