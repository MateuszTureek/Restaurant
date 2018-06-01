using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.WebUI.Infrastructure.Managers
{
    public static class PhotoManager
    {
        public static byte[] GetBytes(HttpPostedFileBase photo)
        {
            if (photo.ContentLength != 0)
            {
                long count = photo.InputStream.Length;
                byte[] photoBytes = new byte[count];
                photo.InputStream.Read(photoBytes, 0, (int)count);
                return photoBytes;
            }
            return null;
        }
    }
}