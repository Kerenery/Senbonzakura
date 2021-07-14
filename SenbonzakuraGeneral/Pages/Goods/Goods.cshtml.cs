using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Senbonzakura.Models;
using Senbonzakura.Services;

namespace SenbonzakuraGeneral.Pages.Goods
{
    public class GoodsModel : PageModel
    {

        private readonly IGoodRepository database;

        public GoodsModel(IGoodRepository database)
        {
            this.database = database;
        }

        public IEnumerable<Good> Goods { get; set; }
        public void OnGet()
        {
            Goods = database.GetAllFGoods();
        }
    }
}