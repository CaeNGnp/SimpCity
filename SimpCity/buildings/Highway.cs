using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpCity.buildings {
    class Highway : CityGridBuilding {
        public static string Name { get; } = "Highway";
        /// <summary>
        /// The 3-character code for the building
        /// </summary>
        public static string Code { get; } = "HWY";

        public Highway(BuildingInfo info) : base(info) {}
    }
}
