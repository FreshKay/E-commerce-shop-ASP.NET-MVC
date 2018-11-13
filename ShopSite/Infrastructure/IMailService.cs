using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSite.Infrastructure
{
    public interface IMailService
    {
        void OrderConfirmaitonMessage(Order order);
        void OrderSendMessage(Order order);
    }
}