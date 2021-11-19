using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpCity.buildings {
    class Highway : CityGridBuilding {
        public static new string Name { get; protected set; } = "Highway";
        /// <summary>
        /// The 3-character code for the building
        /// </summary>
        public static new string Code { get; protected set; } = "HWY";

        public Highway(CityGrid grid) : base(grid) {}
    }
}
