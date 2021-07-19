using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Senbonzakura.Models;
using Senbonzakura.Services;

namespace SenbonzakuraGeneral.Pages.Goods
{
    public class EditModel : PageModel
    {

        private readonly IGoodRepository _database;

        public EditModel(IGoodRepository database)
        {
            _database = database;
        }

        public Good Good { get; set; }
        public IActionResult OnGet(int id)
        {
            Good = _database.GetGood(id);

            if(Good == null) return RedirectToPage("/NotFound");

            return Page();
        }
    }
}