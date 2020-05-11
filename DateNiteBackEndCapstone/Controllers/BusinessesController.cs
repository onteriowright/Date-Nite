using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DateNiteBackEndCapstone.Data;
using DateNiteBackEndCapstone.Models;
using DateNiteBackEndCapstone.Models.BusinessViewModals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DateNiteBackEndCapstone.Controllers
{
    public class BusinessesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BusinessesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Restaurants 
        public async Task<ActionResult> Index(string city, string state, int? budget)
        {
            var client = new HttpClient();
            var price = 0;

            //var viewModel = new BusinessListViewModel();

            //var stateOptions = await _context.States.Select(s => new SelectListItem()
            //{
            //    Text = s.Name,
            //    Value = s.Id.ToString()
            //}).ToListAsync();

            //state = stateOptions.ToString();

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "TeC1Z2BEPysYnC8Ku-w84jo1OG6TSLfLZNol9-2Yj1gEPfpUq76adogQWhyDqbDt3a5Ld_seJQyj5HYK5oIa7WKcloeeZrdWbnwZNJPcea-aLgb4d0K_sZPPvCJUXnYx");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "DateNiteYelpClient");

            HttpResponseMessage response;

            if (city != null && state != null && budget != null)
            {
                if (budget <= 20)
                {
                    price = 1;
                }
                else if (budget >= 20 && budget <= 50)
                {
                    price = 2;
                }
                else if (budget >= 50 && budget <= 75)
                {
                    price = 3;
                }
                else if (budget >= 75 && budget <= 150)
                {
                    price = 4;
                }

                response = await client.GetAsync($"https://api.yelp.com/v3/businesses/search?term=restaurant&open_now=true&location={city},{state}&radius=10000&price={price}&limit=50");
            }
            else
            {
                response = await client.GetAsync($"https://api.yelp.com/v3/businesses/search?term=restaurant&open_now=true&location=Nashville,TN&radius=10000&price=4&limit=50");
            }


            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<BusinessListViewModel>(responseStream);

                return View(data);
            }

            throw new Exception("Unable to retrieve data from Yelp");
        }

        // GET: Events 
        public async Task<ActionResult> EventIndex(string city, BusinessListViewModel state, int? budget)
        {
            var client = new HttpClient();
            var price = 0;

            var viewModel = new BusinessListViewModel();

            var stateOptions = await _context.States.Select(s => new SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToListAsync();

            viewModel.ListOfStateOptions = stateOptions;

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "TeC1Z2BEPysYnC8Ku-w84jo1OG6TSLfLZNol9-2Yj1gEPfpUq76adogQWhyDqbDt3a5Ld_seJQyj5HYK5oIa7WKcloeeZrdWbnwZNJPcea-aLgb4d0K_sZPPvCJUXnYx");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "DateNiteYelpClient");

            HttpResponseMessage response;

            if (city != null && state != null && budget != null)
            {
                if (budget <= 20)
                {
                    price = 1;
                }
                else if (budget >= 20 && budget <= 50)
                {
                    price = 2;
                }
                else if (budget >= 50 && budget <= 75)
                {
                    price = 3;
                }
                else if (budget >= 75 && budget <= 150)
                {
                    price = 4;
                }

                response = await client.GetAsync($"https://api.yelp.com/v3/businesses/search?term=events&open_now=true&location={city},{state}&radius=10000&price={price}&limit=50");
            }
            else
            {
                response = await client.GetAsync($"https://api.yelp.com/v3/businesses/search?term=events&open_now=true&location=Nashville,TN&radius=10000&price=4&limit=50");
            }


            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<BusinessListViewModel>(responseStream);

                return View(data);
            }

            throw new Exception("Unable to retrieve data from Yelp");
        }

        public async Task<ActionResult> ViewBusinessesForScheduledDates(int id)
        {
            var viewModel = new BusinessListViewModel();

            var user = await GetUserAsync();
            var date = await _context.Dates.FirstOrDefaultAsync(d => d.IsScheduled == true && d.UserId == user.Id && d.Id == id);

            var businesses = await _context.Businesses.Where(b => b.DateId == date.Id).ToListAsync();

            viewModel.Date = date;
            viewModel.Businesses = businesses;

            return View(viewModel);
        }

        // GET: Businesses/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var viewModel = new BusinessDetailsViewModel();

            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "TeC1Z2BEPysYnC8Ku-w84jo1OG6TSLfLZNol9-2Yj1gEPfpUq76adogQWhyDqbDt3a5Ld_seJQyj5HYK5oIa7WKcloeeZrdWbnwZNJPcea-aLgb4d0K_sZPPvCJUXnYx");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "DateNiteYelpClient");

            var response = await client.GetAsync($"https://api.yelp.com/v3/businesses/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<Business>(responseStream);

                viewModel.Business = data;

                var locationTypesOptions = await _context.LocationTypes.Select(pt => new SelectListItem()
                {
                    Text = pt.Type,
                    Value = pt.LocationTypeId.ToString()
                }).ToListAsync();

                viewModel.LocationTypesOptions = locationTypesOptions;

                return View(viewModel);
            }

            throw new Exception("Unable to retrieve data from Yelp");
        }

        //POST: Businesses/AddToDate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddToDate(BusinessDetailsViewModel businessDetailViewModel)
        {
            var user = await GetUserAsync();
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "TeC1Z2BEPysYnC8Ku-w84jo1OG6TSLfLZNol9-2Yj1gEPfpUq76adogQWhyDqbDt3a5Ld_seJQyj5HYK5oIa7WKcloeeZrdWbnwZNJPcea-aLgb4d0K_sZPPvCJUXnYx");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "DateNiteYelpClient");

            var response = await client.GetAsync($"https://api.yelp.com/v3/businesses/{businessDetailViewModel.Business.BusinessId}");

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<Business>(responseStream);

                var date = await _context.Dates.FirstOrDefaultAsync(d => d.UserId == user.Id && d.IsScheduled == false);

                var newBusiness = new Business()
                {
                    BusinessId = data.BusinessId,
                    Name = data.Name,
                    Img = data.Img,
                    Phone = data.Phone,
                    Price = data.Price,
                    LocationAddress = data.LocationAddress,
                    Rating = data.Rating,
                    LocationTypeId = businessDetailViewModel.Business.LocationTypeId,
                    UserId = user.Id,
                    DateId = date.Id
                };

                _context.Businesses.Add(newBusiness);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Dates");

                throw new Exception("Unable to retrieve data from Yelp");
            }

            throw new Exception("Unable to retrieve data from Yelp");
        }

        // GET: Businesses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Businesses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET:Businesses/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var business = await _context.Businesses.FirstOrDefaultAsync(b => b.Id == id);

            return View(business);
        }

        // POST: Businesses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var business = await _context.Businesses.FirstOrDefaultAsync(b => b.Id == id);

                _context.Businesses.Remove(business);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Dates");
            }
            catch
            {
                return View();
            }
        }

        private async Task<ApplicationUser> GetUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}