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
        // Methods to set important data send via email
        public void OrderConfirmaitonMessage(Order order)
        {
            OrderConfirmationEmail email = new OrderConfirmationEmail();
            email.To = order.EMail;
            email.From = "";
            email.Value = order.OrderValue;
            email.OrderNumber = order.OrderId;
            email.ItemPositions = order.ItemPosition;
            email.Send();
        }

        public void OrderSendMessage(Order order)
        {
            OrderSendEmail email = new OrderSendEmail();
            email.To = order.EMail;
            email.From = "";
            email.OrderNumber = order.OrderId;
            email.Send();
        }

    }
}