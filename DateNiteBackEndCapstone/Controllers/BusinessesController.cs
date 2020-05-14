using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DateNiteBackEndCapstone.Data;
using DateNiteBackEndCapstone.Models;
using DateNiteBackEndCapstone.Models.BusinessViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DateNiteBackEndCapstone.Controllers
{
    public class BusinessesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public readonly IConfiguration _config;

        public BusinessesController(IConfiguration config, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
        }

        public async Task<ActionResult> SearchEatery()
        {
            var viewModel = new SearchBusinessViewModel();

            var stateOptions = await _context.States.Select(s => new SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToListAsync();

            viewModel.ListOfStateOptions = stateOptions;

            return View(viewModel);
        }

        public async Task<ActionResult> SearchFun()
        {
            var viewModel = new SearchBusinessViewModel();

            var stateOptions = await _context.States.Select(s => new SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToListAsync();

            viewModel.ListOfStateOptions = stateOptions;

            return View(viewModel);
        }

        // GET: Restaurants 
        public async Task<ActionResult> Index(string city, string state, int? budget)
        {
            var client = new HttpClient();
            var price = 0;

            switch (state)
            {
                case "1":
                    state = "AL";
                    break;
                case "2":
                    state = "AK";
                    break;
                case "3":
                    state = "AZ";
                    break;
                case "4":
                    state = "AR";
                    break;
                case "5":
                    state = "CA";
                    break;
                case "6":
                    state = "CO";
                    break;
                case "7":
                    state = "CT";
                    break;
                case "8":
                    state = "DE";
                    break;
                case "9":
                    state = "FI";
                    break;
                case "10":
                    state = "GA";
                    break;
                case "11":
                    state = "HI";
                    break;
                case "12":
                    state = "ID";
                    break;
                case "13":
                    state = "IL";
                    break;
                case "14":
                    state = "IN";
                    break;
                case "15":
                    state = "IA";
                    break;
                case "16":
                    state = "KS";
                    break;
                case "17":
                    state = "KY";
                    break;
                case "18":
                    state = "LA";
                    break;
                case "19":
                    state = "ME";
                    break;
                case "20":
                    state = "MD";
                    break;
                case "21":
                    state = "MA";
                    break;
                case "22":
                    state = "MI";
                    break;
                case "23":
                    state = "MN";
                    break;
                case "24":
                    state = "MS";
                    break;
                case "25":
                    state = "MO";
                    break;
                case "26":
                    state = "MT";
                    break;
                case "27":
                    state = "NE";
                    break;
                case "28":
                    state = "NV";
                    break;
                case "29":
                    state = "NH";
                    break;
                case "30":
                    state = "NJ";
                    break;
                case "31":
                    state = "NM";
                    break;
                case "32":
                    state = "NY";
                    break;
                case "33":
                    state = "NC";
                    break;
                case "34":
                    state = "ND";
                    break;
                case "35":
                    state = "OH";
                    break;
                case "36":
                    state = "OK";
                    break;
                case "37":
                    state = "OR";
                    break;
                case "38":
                    state = "PA";
                    break;
                case "39":
                    state = "RI";
                    break;
                case "40":
                    state = "SC";
                    break;
                case "41":
                    state = "SD";
                    break;
                case "42":
                    state = "TN";
                    break;
                case "43":
                    state = "TX";
                    break;
                case "44":
                    state = "UT";
                    break;
                case "45":
                    state = "VT";
                    break;
                case "46":
                    state = "VA";
                    break;
                case "47":
                    state = "WA";
                    break;
                case "48":
                    state = "WV";
                    break;
                case "49":
                    state = "WI";
                    break;
                case "50":
                    state = "WY";
                    break;
            }

            var yelpAccount = new YelpAccount();

            _config.GetSection("YelpAccount").Bind(yelpAccount);

            var authToken = yelpAccount.KEY;

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + $"{authToken}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "DateNiteYelpClient");

            HttpResponseMessage response;

            if (city != null && state != null && budget != null)
            {
                if (budget <= 20)
                {
                    price = 1;
                }
                else if (budget >= 20 && budget < 50)
                {
                    price = 2;
                }
                else if (budget >= 50 && budget < 75)
                {
                    price = 3;
                }
                else if (budget >= 75)
                {
                    price = 4;
                }

                response = await client.GetAsync($"https://api.yelp.com/v3/businesses/search?term=restaurant&open_now=true&location={city},{state}&radius=10000&price={price}");


                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var data = await JsonSerializer.DeserializeAsync<BusinessListViewModel>(responseStream);

                    return View(data);
                }
            }

            throw new Exception("Unable to retrieve data from Yelp");
        }

        // GET: Events 
        public async Task<ActionResult> EventIndex(string city, string state, int? budget)
        {
            var client = new HttpClient();
            var price = 0;

            switch (state)
            {
                case "1":
                    state = "AL";
                    break;
                case "2":
                    state = "AK";
                    break;
                case "3":
                    state = "AZ";
                    break;
                case "4":
                    state = "AR";
                    break;
                case "5":
                    state = "CA";
                    break;
                case "6":
                    state = "CO";
                    break;
                case "7":
                    state = "CT";
                    break;
                case "8":
                    state = "DE";
                    break;
                case "9":
                    state = "FI";
                    break;
                case "10":
                    state = "GA";
                    break;
                case "11":
                    state = "HI";
                    break;
                case "12":
                    state = "ID";
                    break;
                case "13":
                    state = "IL";
                    break;
                case "14":
                    state = "IN";
                    break;
                case "15":
                    state = "IA";
                    break;
                case "16":
                    state = "KS";
                    break;
                case "17":
                    state = "KY";
                    break;
                case "18":
                    state = "LA";
                    break;
                case "19":
                    state = "ME";
                    break;
                case "20":
                    state = "MD";
                    break;
                case "21":
                    state = "MA";
                    break;
                case "22":
                    state = "MI";
                    break;
                case "23":
                    state = "MN";
                    break;
                case "24":
                    state = "MS";
                    break;
                case "25":
                    state = "MO";
                    break;
                case "26":
                    state = "MT";
                    break;
                case "27":
                    state = "NE";
                    break;
                case "28":
                    state = "NV";
                    break;
                case "29":
                    state = "NH";
                    break;
                case "30":
                    state = "NJ";
                    break;
                case "31":
                    state = "NM";
                    break;
                case "32":
                    state = "NY";
                    break;
                case "33":
                    state = "NC";
                    break;
                case "34":
                    state = "ND";
                    break;
                case "35":
                    state = "OH";
                    break;
                case "36":
                    state = "OK";
                    break;
                case "37":
                    state = "OR";
                    break;
                case "38":
                    state = "PA";
                    break;
                case "39":
                    state = "RI";
                    break;
                case "40":
                    state = "SC";
                    break;
                case "41":
                    state = "SD";
                    break;
                case "42":
                    state = "TN";
                    break;
                case "43":
                    state = "TX";
                    break;
                case "44":
                    state = "UT";
                    break;
                case "45":
                    state = "VT";
                    break;
                case "46":
                    state = "VA";
                    break;
                case "47":
                    state = "WA";
                    break;
                case "48":
                    state = "WV";
                    break;
                case "49":
                    state = "WI";
                    break;
                case "50":
                    state = "WY";
                    break;
            }

            var yelpAccount = new YelpAccount();

            _config.GetSection("YelpAccount").Bind(yelpAccount);

            var authToken = yelpAccount.KEY;

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + $"{authToken}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "DateNiteYelpClient");

            HttpResponseMessage response;

            if (city != null && state != null && budget != null)
            {
                if (budget <= 20)
                {
                    price = 1;
                }
                else if (budget >= 20 && budget < 50)
                {
                    price = 2;
                }
                else if (budget >= 50 && budget < 75)
                {
                    price = 3;
                }
                else if (budget >= 75)
                {
                    price = 4;
                }

                response = await client.GetAsync($"https://api.yelp.com/v3/businesses/search?term=events&open_now=true&location={city},{state}&radius=10000&price={price}&limit=50");

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var data = await JsonSerializer.DeserializeAsync<BusinessListViewModel>(responseStream);

                    return View(data);
                }
            }

            throw new Exception("Unable to retrieve data from Yelp");
        }

        public async Task<ActionResult> ViewBusinessesForScheduledDates(int id)
        {
            var viewModel = new BusinessListViewModel();

            var user = await GetUserAsync();
            var date = await _context.Dates.FirstOrDefaultAsync(d => d.IsScheduled == true && d.UserId == user.Id && d.Id == id);

            var businesses = await _context.Businesses
                .Include(b => b.LocationType)
                .Where(b => b.DateId == date.Id).ToListAsync();

            viewModel.Date = date;
            viewModel.Businesses = businesses;

            return View(viewModel);
        }

        // GET: Businesses/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var viewModel = new BusinessDetailsViewModel();

            var client = new HttpClient();

            var yelpAccount = new YelpAccount();

            _config.GetSection("YelpAccount").Bind(yelpAccount);

            var authToken = yelpAccount.KEY;

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + $"{authToken}");
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

            var yelpAccount = new YelpAccount();

            _config.GetSection("YelpAccount").Bind(yelpAccount);

            var authToken = yelpAccount.KEY;

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + $"{authToken}");
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
            }

            throw new Exception("Unable to retrieve data from Yelp");
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