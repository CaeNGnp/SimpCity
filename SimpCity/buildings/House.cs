using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpCity.buildings {
    class House : CityGridBuilding {
        public static new string Name { get; protected set; } = "House";
        /// <summary>
        /// The 3-character code for the building
        /// </summary>
        public static new string Code { get; protected set; } = "HSE";

        public House(CityGrid grid) : base(grid) {}
    }
}
