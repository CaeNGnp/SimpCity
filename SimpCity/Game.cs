using System;
using System.Collections.Generic;
using SimpCity.buildings;

namespace SimpCity {
    enum BuildingTypes {
        Beach,
        Factory,
        Highway,
        House,
        Shop
    }

    class BuildingInfo {
        public BuildingTypes Type { get; set; }
        /// <summary>
        /// The 3-character code for the building
        /// </summary>
        public string Code { get; set; }
        public int CopiesLeft { get; set; }
        public Action MakeNew { get; set; }
    }

    class Game {
        private const int GRID_WIDTH = 4;
        private const int GRID_HEIGHT = 4;
        private const int MAX_ROUNDS = GRID_WIDTH * GRID_HEIGHT;
        private const int BUILDING_COPIES = 8;


        private readonly IDictionary<BuildingTypes, BuildingInfo> buildingInfo;
        private readonly CityGrid grid;
        private int round;

        public Game() {
            grid = new CityGrid(GRID_WIDTH, GRID_HEIGHT);
            round = 0;

            // Exhaustive list of buildings and their operations.
            // Type & CopiesLeft are automatically assigned after this.
            buildingInfo = new Dictionary<BuildingTypes, BuildingInfo>() {
                {
                    BuildingTypes.Beach, new BuildingInfo() {
                        Code = Beach.Code,
                        MakeNew = () => new Beach(grid)
                    }
                },
                {
                    BuildingTypes.Factory, new BuildingInfo() {
                        Code = Factory.Code,
                        MakeNew = () => new Factory(grid)
                    }
                },
                {
                    BuildingTypes.Highway, new BuildingInfo() {
                        Code = Highway.Code,
                        MakeNew = () => new Highway(grid)
                    }
                },
                {
                    BuildingTypes.House, new BuildingInfo() {
                        Code = House.Code,
                        MakeNew = () => new House(grid)
                    }
                },
                {
                    BuildingTypes.Shop, new BuildingInfo() {
                        Code = Shop.Code,
                        MakeNew = () => new Shop(grid)
                    }
                }
            };

            // Assign Type and CopiesLeft
            foreach (var item in buildingInfo) {
                item.Value.Type = item.Key;
                item.Value.CopiesLeft = BUILDING_COPIES;
            }
        }

        private void DisplayGrid() {
            Console.WriteLine("Turn " + round);
            // TODO
        }

        private void MakeMove(CityGridBuilding building) {
            round++;
            // TODO
        }

        public void Save() {
            // TODO: US-3 - save state
            throw new NotImplementedException();
        }

        public void Restore() {
            // TODO: US-5 - restore state
            throw new NotImplementedException();
        }

        public void Play() {
            ConsoleMenu menu = new ConsoleMenu().BeforeInteraction(DisplayGrid);

            // Add option for random 2 buildings
            var a = buildingTypes.OrderBy(x => rnd.Next()).Take(5);

            for () {
                menu.AddOption("See remaining buildings")
                .AddHeading()
                .AddOption("Save game", (_cmd) => Console.WriteLine("Todo save game"))
                .AddExitOption("Exit to main menu");
            }

            menu.DisplayInteraction();

            throw new NotImplementedException();
        }
    }
}
