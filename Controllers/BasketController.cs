
using LabWork.Data;
using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using LabWork.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LabWork.Controllers
{
    public class BasketController : Controller
    {
        private readonly IUsers allUsers;
        private readonly IDigitalCopy allCopies;
        private readonly IUserOrder allOrders;
        private readonly UserManager<User> _userManager;
        private readonly AppDBContent _appDBContent;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketController(IUsers allUsers, IDigitalCopy allCopies, IUserOrder allOrders, UserManager<User> userManager, AppDBContent appDBContent, IHttpContextAccessor httpContextAccessor)
        {
            this.allUsers = allUsers;
            this.allCopies = allCopies;
            this.allOrders = allOrders;
            _userManager = userManager;
            _appDBContent = appDBContent;
            _httpContextAccessor = httpContextAccessor;
        }

        public ViewResult List()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            UserOrderCheckoutModel signedUser = new UserOrderCheckoutModel();
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null) signedUser = new UserOrderCheckoutModel(user.Name, user.Surname, user.Email);
            return View(signedUser);
        }

        [HttpPost]
        public async Task<int> Checkout([FromBody] UserOrderCheckoutModel order)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<DigitalCopy> copies = allCopies.allCopies.ToList();
            List<User> users = allUsers.allUsers.ToList();

            UserOrder userOrder = new UserOrder();
            List<UserOrderItem> items = new List<UserOrderItem>();
            userOrder.createdTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            userOrder.Status = "Нове";
            userOrder.price = order.total_price;

            foreach (var copy in copies)
            {
                for (var i = 0; i < order.games.Count; i+=4)
                {
                    if (Int32.Parse(order.games[i]) == copy.gameId && order.games[i+2] == copy.platform)
                    {
                        items.Add(new UserOrderItem { amount = Int32.Parse(order.games[i + 3]), price = (int)copy.price, item = copy });
                    }
                }
            }
            userOrder.OrderItemsList = items;

            // validation on server side
            int validatedForm = userOrder.validateForm(order);
            int validatedItems = allOrders.validateItems(userOrder);

            var dbUser = await _userManager.FindByEmailAsync(order.email);
            if (validatedForm == 10 && validatedItems == 10)
            {
                // identifying customer's id
                if (dbUser != null) userOrder.customerId = dbUser.Id;
                else
                {
                    var user = new User
                    {
                        Name = order.name,
                        Surname = order.surname,
                        UserName = order.email,
                        Email = order.email,
                        Role = "Customer"
                    };
                    var result = await _userManager.CreateAsync(user);
                    userOrder.customerId = user.Id;
                    Console.WriteLine(user.Id);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, Helper.Helper.Customer);
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                // add order to DB
                allOrders.addOrder(userOrder);
                return 10;
            }
            if (validatedForm != 10 && validatedItems != 10 || validatedItems != 10) return validatedItems;
            if (validatedForm != 10 && validatedItems == 10) return validatedForm;
            else return 40;
        }
    }
}
