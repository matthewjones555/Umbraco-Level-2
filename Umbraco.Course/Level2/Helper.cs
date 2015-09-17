using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Linq;
using Newtonsoft.Json;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Course.Models;
using Umbraco.Web;

namespace Umbraco.Course.Level2
{
    public static class Helper
    {
        // File extension methods.

        public static bool HasFiles(this IEnumerable<HttpPostedFileBase> files)
        {
            return files.First() != null && files.First().ContentLength > 0;
        }

        public static bool ContainsImages(this IEnumerable<HttpPostedFileBase> files)
        {
            return files.Any(file => file.IsImage());
        }

        public static bool IsImage(this HttpPostedFileBase file)
        {
            if (file.ContentType.Contains("image"))
            {
                return true;
            }

            var formats = new[] { ".jpg", ".png", ".gif", ".jpeg" };
            return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }

        // Marco Parameter extension methods

        public static T GetValue<T>(this IDictionary<string, object> dictionary, string key)
        {
            return dictionary.GetValue(key, default(T));
        }

        public static T GetValue<T>(this IDictionary<string, object> dictionary, string key, T defaultValue)
        {
            if (!dictionary.ContainsKey(key) || string.IsNullOrEmpty(dictionary[key].ToString())) return defaultValue;
            return (T)Convert.ChangeType(dictionary[key], typeof(T));
        }

        public static void SetPickupDirectoryLocation(this SmtpClient smtpClient)
        {
            if (smtpClient.PickupDirectoryLocation == null || Path.IsPathRooted(smtpClient.PickupDirectoryLocation))
                return;

            // If PickupDirectory is relative, change it to absolute
            smtpClient.PickupDirectoryLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                smtpClient.PickupDirectoryLocation);

            if (Directory.Exists(smtpClient.PickupDirectoryLocation) == false)
                Directory.CreateDirectory(smtpClient.PickupDirectoryLocation);
        }
        //public static void PopulatePaging(Umbraco.Course.Models.StreamModel stream)
        //{
        //    const int pageSize = 5;
        //    var skipItems = (pageSize * stream.Page) - pageSize;

        //    var posts = stream.Content.Children.ToList();
        //    stream.TotalPages = Convert.ToInt32(Math.Ceiling((double)posts.Count() / pageSize));

        //    stream.PreviousPage = stream.Page - 1;
        //    stream.NextPage = stream.Page + 1;

        //    stream.IsFirstPage = stream.Page <= 1;
        //    stream.IsLastPage = stream.Page >= stream.TotalPages;

        //    stream.StatusUpdates = posts.OrderByDescending(x => x.CreateDate).Skip(skipItems).Take(pageSize);
        //}
    }
}