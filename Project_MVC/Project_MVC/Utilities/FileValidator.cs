using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Project_MVC.Utilities
{
    public static class FileValidator
    {
        public static async Task<string> FileCreate(this IFormFile file, string root, string folder)
        {
            string Name =file.FileName;
            string path = Path.Combine(root, folder);
            string Location = Path.Combine(path, Name);
            try
            {
                using (FileStream stream = new FileStream(Location, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception)
            {

                throw new FileLoadException();
            }
            return Name;
        }

        public static void FileDelete(string root, string folder, string image)
        {
            string filePath = Path.Combine(root, folder, image);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static bool CheckImage(this IFormFile file, int mb)
        {
            return file.Length / 1024 / 1024 < mb && file.ContentType.Contains("image/");

        }
    }
}
