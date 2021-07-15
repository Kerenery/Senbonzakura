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

        private readonly IEnumerable<Good> allGoods;

        public GoodsDBRepository()
        {
            allGoods = new List<Good>()
            {
                new Good() {Color = "black", Id = 1, PhotoPath = "smth.png", Type = GoodsKinds.skirt},
                new Good() {Color = "white", Id = 2, PhotoPath = "smth2.jpg", Type = GoodsKinds.pant},
                new Good() {Color = "blue", Id = 3, Type = GoodsKinds.sundress},
                new Good() {Color = "green", Id = 4, Type = GoodsKinds.pant}
            };
        }

        public IEnumerable<Good> GetAllFGoods()
        {
            return allGoods;
        }
    }
}
