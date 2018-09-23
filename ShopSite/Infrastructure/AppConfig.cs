using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ShopSite.Infrastructure
{
    public class AppConfig
    {
        private static string _picturesFolder = ConfigurationManager.AppSettings["PicturesFolder"];

        public static string PicturesFolder
        {
            get
            {
                return _picturesFolder;
            }
        }
    }
}