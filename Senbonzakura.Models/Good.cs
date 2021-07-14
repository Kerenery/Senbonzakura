using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senbonzakura.Models
{
    public class Good
    {
        public string Color { get; set; }
        public int Id { get; set; }
        public GoodsKinds? Type { get; set; }
        public string PhotoPath { get; set; }
    }
}
