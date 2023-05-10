using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using LabWork.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace LabWork.Controllers
{
    public class UserOrdersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IUserOrder _allOrders;
        private readonly IUsers _allUsers;
        private readonly IDigitalCopy _allDigitalCopies;
        private readonly IGames _allGames;
        private readonly IOrderBasket _allOrderBaskets;
        private readonly IGameKey _allGameKeys;

        public UserOrdersController(IUserOrder allOrders, IUsers allUsers, IDigitalCopy allDigitalCopies, 
            IGames allGames, IOrderBasket allOrderBaskets, IGameKey allGameKeys, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _allOrders = allOrders; 
            _allUsers = allUsers;
            _allDigitalCopies = allDigitalCopies;
            _allGames = allGames;
            _allOrderBaskets = allOrderBaskets;
            _allGameKeys = allGameKeys;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public ViewResult List()
        {
            var userOrders = _allOrders.allOrders;
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            List<UserOrdersListViewModel> ordersForm = new List<UserOrdersListViewModel>();
            string gameName;
            string platformName;
            foreach(var userOrder in _allOrders.OrdersByCustomerId(userId))
            {
                var orderedGames = new List<(string, string, double, int)>();
                foreach(var key in _allOrderBaskets.basketByOrderId(userOrder.Id))
                {
                    int copyId = _allGameKeys.KeyById(key.keyId).digitalCopyId;
                    int gameId = _allDigitalCopies.CopyById(copyId).gameId;
                    gameName = _allGames.gameById(gameId).name;
                    platformName = _allDigitalCopies.CopyById(_allGameKeys.KeyById(key.keyId).digitalCopyId).platform;
                    orderedGames.Add((gameName, platformName, key.price, _allGameKeys.numKeysByDigitalId(copyId, userOrder.Id)));
                }
                ordersForm.Add(new UserOrdersListViewModel
                {
                    userCustomer = _allUsers.UserById(userOrder.customerId),
                    userOperator = _allUsers.UserById(userOrder.operatorId),
                    order = userOrder,
                    gamePlatformPrice = orderedGames
                });
            }
            return View(ordersForm);
        }
    }
}
