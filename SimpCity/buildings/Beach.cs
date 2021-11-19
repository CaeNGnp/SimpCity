using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpCity.buildings {
    class Beach : CityGridBuilding {
        public static string Name { get; } = "Beach";
        /// <summary>
        /// The 3-character code for the building
        /// </summary>
        public static string Code { get; } = "BCH";
        public Beach(BuildingInfo info) : base(info) {}
    }
}
