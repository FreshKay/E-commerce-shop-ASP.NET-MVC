using Hangfire;
using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSite.Infrastructure
{
    public class HangfireMailService : IMailService
    {
        public void OrderConfirmaitonMessage(Order order)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("OrderConfirmaitonMessage", "Manage", new { orderId = order.OrderId, surname = order.Surname }, HttpContext.Current.Request.Url.Scheme);

            BackgroundJob.Enqueue(() => Helpers.CallUrl(url));
        }

        public void OrderSendMessage(Order order)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("OrderSendMessage", "Manage", new { orderID = order.OrderId, surname = order.Surname }, HttpContext.Current.Request.Url.Scheme);

            BackgroundJob.Enqueue(() => Helpers.CallUrl(url));
        }
    }
}