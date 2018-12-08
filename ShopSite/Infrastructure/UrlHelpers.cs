using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSite.Infrastructure
{
    public static class UrlHelpers
    {
        //Creates path to pictures
        public static string PicturePath(this UrlHelper helper, string namePicture)
        {
            var pictureFolder = AppConfig.PicturesFolder;
            var path = Path.Combine(pictureFolder, namePicture);
            var path_2 = helper.Content(path);

            return path_2;
        }
    }
}