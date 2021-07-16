using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senbonzakura.Models;

namespace Senbonzakura.Services
{

    public interface IGoodRepository
    {
        IEnumerable<Good> GetAllFGoods();

        Good GetGood(int id);
    }
}
