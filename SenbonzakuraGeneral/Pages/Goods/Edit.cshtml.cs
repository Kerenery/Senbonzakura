using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Senbonzakura.Models;
using Senbonzakura.Services;

namespace SenbonzakuraGeneral.Pages.Goods
{
    public class EditModel : PageModel
    {

        private readonly IGoodRepository _database;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private string UploadPhoto()
        {
            string currentFileName = null;

            if (Photo != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                currentFileName = Guid.NewGuid().ToString() + '_' + Photo.FileName;
                string photoPath = Path.Combine(uploadFolder, currentFileName);

                using (var filestream = new FileStream(photoPath, FileMode.Create))
                {
                    Photo.CopyTo(filestream);
                }
            }

            return currentFileName;
        }

        public EditModel(IGoodRepository database, IWebHostEnvironment webHostEnvironment)
        {
            _database = database;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Good Good { get; set; }

        // благодаря данной штуке Photo досупно во всех Post методах
        [BindProperty]
        public IFormFile Photo { get; set; }

        public IActionResult OnGet(int id)
        {
            Good = _database.GetGood(id);

            if(Good == null) return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost(Good good)
        {
            if (Photo != null)
            {
                if (good.PhotoPath != null)
                {
                    if (good.PhotoPath != "~/images/standard.jpg")
                    {
                        string filepath = Path.Combine(_webHostEnvironment.WebRootPath, "images", good.PhotoPath);
                        //System.IO.File.Delete(filepath);
                    }
                }

                good.PhotoPath = UploadPhoto();
            }

            Good = _database.UpDate(good);
            return RedirectToPage("/Goods/Goods");
        }
    }
}