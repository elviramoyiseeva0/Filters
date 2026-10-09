using Microsoft.AspNetCore.Mvc.Filters;
using Сurrency.Data;
using Сurrency.Models;

namespace Сurrency.Filters
{
    public class CurrencyResourceFilter : IResourceFilter
    {
        private readonly ApplicationContext _context;

        public CurrencyResourceFilter(ApplicationContext context)
        {
            _context = context;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string currency = context.HttpContext.Request.Query["currency"].ToString();

            if (!string.IsNullOrEmpty(currency))
            {
                string userId = "currentUser";

                var userCurrency = _context.UserCurrencies.FirstOrDefault(u => u.UserId == userId);

                if (userCurrency == null)
                {
                    userCurrency = new UserCurrency { UserId = userId, CurrencyCode = currency };
                    _context.UserCurrencies.Add(userCurrency);
                }
                else
                {
                    userCurrency.CurrencyCode = currency;
                }

                _context.SaveChanges();
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
