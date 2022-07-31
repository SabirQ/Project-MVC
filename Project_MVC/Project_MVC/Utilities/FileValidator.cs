﻿using Microsoft.AspNetCore.Http;
using Project_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Project_MVC.Utilities
{
    public static class FileValidator
    {
        public static async Task<string> FileCreate(this IFormFile file,string filename, string root, string folder)
        {
            string Name = filename;
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
        public static decimal CheckDiscount(this Product product)
        {
            if (product.DiscountId!=null&&product.DiscountId!=0)
            {
                return product.Price - product.Price * product.Discount.Value / 100;
            }
            return product.Price;

        }
    }
}
