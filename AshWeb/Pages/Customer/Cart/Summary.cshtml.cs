using ash.DataAccess.Migrations;
using ash.DataAccess.Repository.IRepository;
using Ash.Models;
using Ash.Models.Model;
using Ash.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe.Checkout;
using System.Security.Claims;

namespace AshWeb.Pages.Customer.Cart
{
    [Authorize]
    [BindProperties]
    public class SummaryModel : PageModel
    {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        public OrderHeader OrderHeader { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        public SummaryModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            OrderHeader = new OrderHeader();
        }
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(filter: u => u.ApplicationUserid == claim.Value,
                    includeProperties: "MenuItem,MenuItem.Food,MenuItem.Category");
                foreach (var cartItem in ShoppingCartList)
                {
                    OrderHeader.OrderTotal += (cartItem.MenuItem.Price * cartItem.Count);
                }
                ApplicationUsers ApplicationUsers = _unitOfWork.ApplicationUsers.GetFirstOrDefault(u => u.Id == claim.Value);
                OrderHeader.PickUpName = ApplicationUsers.FirstName + " " + ApplicationUsers.LastName;
                OrderHeader.PhoneNumber = ApplicationUsers.PhoneNumber;

            }
        }

        public IActionResult OnPost()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(filter: u => u.ApplicationUserid == claim.Value,
                    includeProperties: "MenuItem,MenuItem.Food,MenuItem.Category");
                foreach (var cartItem in ShoppingCartList)
                {
                    OrderHeader.OrderTotal += (cartItem.MenuItem.Price * cartItem.Count);
                }
                OrderHeader.Status = SD.StatusPending;
                OrderHeader.OrderDate = System.DateTime.Now;
                OrderHeader.UserId = claim.Value;
                OrderHeader.PickUpTime = Convert.ToDateTime(OrderHeader.PickUpDate.ToShortDateString() + " "+ OrderHeader.PickUpTime.ToShortTimeString());
                _unitOfWork.OrderHeader.Add(OrderHeader);
                _unitOfWork.Save();

                foreach(var item in  ShoppingCartList)
                {
                    OrderDetails OrderDetails = new()
                    {
                        MenuItemid = item.MenuItemid,
                        OrderId = OrderHeader.Id,
                        Name = item.MenuItem.Name,
                        Price = item.MenuItem.Price,
                        Count = item.Count
                    };
                    _unitOfWork.OrderDetails.Add(OrderDetails);
                    _unitOfWork.Save();
                }
                int quantity = ShoppingCartList.ToList().Count;
                _unitOfWork.ShoppingCart.RemoveRange(ShoppingCartList);
                _unitOfWork.Save();

                var domain = "http://localhost:44341";
                var options = new SessionCreateOptions
                {
                    LineItems = new List<SessionLineItemOptions>
                    {
                        new SessionLineItemOptions
                        {
                            PriceData = new SessionLineItemPriceDataOptions
                            {
                                UnitAmount = (long)OrderHeader.OrderTotal*100,
                                Currency="INR",
                                ProductData = new SessionLineItemPriceDataProductDataOptions
                                {
                                    Name = "Ashish Food Order"
                                    
                                },

                            },
                            Quantity = 1
                        },
                    },
                    PaymentMethodTypes = new List<string>
                    {
                        "card",
                    },
                    Mode = "payment",
                    SuccessUrl = domain + @"/customer/cart/OrderConfirmation?id={OrderHeader.Id}",
                    CancelUrl = domain + "/customer/cart/Index",

                };
                var service = new SessionService();
                Session session = service.Create(options);
                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303);
            }
            return Page();
        }

    }
}
