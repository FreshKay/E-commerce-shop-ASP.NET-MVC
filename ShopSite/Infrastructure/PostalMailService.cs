using ShopSite.Models;
using ShopSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSite.Infrastructure
{
    public class PostalMailService : IMailService
    {
        public void OrderConfirmaitonMessage(Order order)
        {
            OrderConfirmationEmail email = new OrderConfirmationEmail();
            email.To = order.EMail;
            email.From = "mikolaj.jon@gmail.com";
            email.Value = order.OrderValue;
            email.OrderNumber = order.OrderId;
            email.ItemPositions = order.ItemPosition;
            email.Send();
        }

        public void OrderSendMessage(Order order)
        {
            OrderSendEmail email = new OrderSendEmail();
            email.To = order.EMail;
            email.From = "mikolaj.jon@gmail.com";
            email.OrderNumber = order.OrderId;
            email.Send();
        }

    }
}