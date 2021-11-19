using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpCity.buildings {
    class Factory : CityGridBuilding {
        public static string Name { get; } = "Factory";
        /// <summary>
        /// The 3-character code for the building
        /// </summary>
        public static string Code { get; } = "FAC";
        public Factory(BuildingInfo info) : base(info) {}
    }
}
