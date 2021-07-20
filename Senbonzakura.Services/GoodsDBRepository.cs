using Senbonzakura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senbonzakura.Services
{
    public class GoodsDBRepository : IGoodRepository
    {

        private readonly IEnumerable<Good> _allGoods;

        public GoodsDBRepository()
        {
            _allGoods = new List<Good>()
            {
                new Good() {Color = "black", Id = 1, PhotoPath = "smth.png", Type = GoodsKinds.baka},
                new Good() {Color = "white", Id = 2, PhotoPath = "smth2.jpg", Type = GoodsKinds.manko},
                new Good() {Color = "blue", Id = 3, Type = GoodsKinds.kasu},
                new Good() {Color = "green", Id = 4, Type = GoodsKinds.baka}
            };
        }

        public IEnumerable<Good> GetAllFGoods()
        {
            return _allGoods;
        }

        public Good GetGood(int id)
        {
            return _allGoods.FirstOrDefault(x => x.Id == id);
        }

        public Good UpDate(Good updGood)
        {
            Good good = _allGoods.FirstOrDefault(x => x.Id == updGood.Id);

            if (good != null)
            {
                good.Id = updGood.Id;
                good.Type = updGood.Type;
                good.Color = updGood.Color;
                good.PhotoPath = updGood.PhotoPath;
            }

            return good;
        }
    }
}
