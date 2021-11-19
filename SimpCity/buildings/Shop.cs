using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpCity.buildings {
    class Shop : CityGridBuilding {
        public static string Name { get; } = "Shop";
        /// <summary>
        /// The 3-character code for the building
        /// </summary>
        public static string Code { get; } = "SHP";

        public Shop(BuildingInfo info) : base(info) {}
    }
}
