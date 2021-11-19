using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpCity.buildings {
    class Shop : CityGridBuilding {
        public static new string Name { get; protected set; } = "Shop";
        /// <summary>
        /// The 3-character code for the building
        /// </summary>
        public static new string Code { get; protected set; } = "SHP";

        public Shop(CityGrid grid) : base(grid) {}
    }
}
