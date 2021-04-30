using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Entities
{
    public class HouseImage
    {
        public int ID { get; set; }
        public int HouseID { get; set; }
        public virtual House House { get; set; }
        public byte[] Image { get; set; }
    }
}
