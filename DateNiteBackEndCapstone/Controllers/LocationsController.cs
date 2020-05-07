using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DateNiteBackEndCapstone.Data;
using DateNiteBackEndCapstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DateNiteBackEndCapstone.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LocationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Locations
        public async Task<ActionResult> Index(string city, string state, int? budget)
        {
            var client = new HttpClient();
            var price = 0;

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
                var data = await JsonSerializer.DeserializeAsync<DateResults>(responseStream);

                return View(data);
                throw new Exception("Unable to retrieve data from Yelp");
            }
            return View();
        }

        // GET: Locations/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "TeC1Z2BEPysYnC8Ku-w84jo1OG6TSLfLZNol9-2Yj1gEPfpUq76adogQWhyDqbDt3a5Ld_seJQyj5HYK5oIa7WKcloeeZrdWbnwZNJPcea-aLgb4d0K_sZPPvCJUXnYx");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "DateNiteYelpClient");

            var response = await client.GetAsync($"https://api.yelp.com/v3/businesses/{id}");

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<Business>(responseStream);

                return View(data);
                throw new Exception("Unable to retrieve data from Yelp");
            }

            return View();
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
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

        // GET: Locations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Locations/Edit/5
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

        // GET: Locations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Locations/Delete/5
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