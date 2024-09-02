using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageAndroidUpdates.Helper
{
    public class FileHelper
    {
        public static string GetFileNameFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("La URL no puede estar vacía o ser nula.", nameof(url));
            }

            System.Uri uri = new System.Uri(url);
            return Path.GetFileName(uri.LocalPath);
        }


        public static string GetFilePath(string fileName)
        {
            var filePath = Path.Combine(FileSystem.CacheDirectory, fileName);
            return filePath;
        }
    }
}
