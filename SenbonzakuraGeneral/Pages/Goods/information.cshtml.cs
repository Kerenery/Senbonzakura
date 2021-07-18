using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Senbonzakura.Models;
using Senbonzakura.Services;

namespace SenbonzakuraGeneral.Pages.Goods
{
    public class InformationModel : PageModel
    {

        private readonly IGoodRepository database;

        public InformationModel(IGoodRepository database)
        {
            this.database = database;
        }

        public IEnumerable<Good> Goods { get; set; }
        public Good Good { get; private set; }

        public IActionResult OnGet(int id)
        {
            Good = database.GetGood(id);

            if (Good == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
    }
}