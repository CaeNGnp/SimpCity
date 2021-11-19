using System;
using System.Collections.Generic;

namespace SimpCity {
    class ConsoleMenuCommand {
        public bool ExitNext { get; set; } = false;

        /// <summary>
        /// For interactive displays, this signals the console menu to return after the command
        /// callback is completed.
        /// </summary>
        public void Exit(bool exit = true) {
            this.ExitNext = exit;
        }
    }

    class ConsoleMenuOption {
        public string Label { get; set; }
        public string Description { get; set; }
        public Action<ConsoleMenuCommand> Callback { get; set; }

        public ConsoleMenuOption(string label, string description, Action<ConsoleMenuCommand> callback = null) {
            this.Label = label;
            this.Description = description;
            this.Callback = callback;
        }
    }

    class ConsoleMenuHeading {
        public string Description { get; set; }

        /// <param name="description">If this is `null`, it can act as a single line padding.</param>
        public ConsoleMenuHeading(string description = null) {
            this.Description = description;
        }
    }

    /// <summary>
    /// Creates an interactive console menu
    /// </summary>
    class ConsoleMenu {
        private readonly List<ConsoleMenuOption> options;
        private readonly IDictionary<string, ConsoleMenuOption> optionsMap = new Dictionary<string, ConsoleMenuOption>();
        private readonly IDictionary<int, ConsoleMenuHeading> headings = new Dictionary<int, ConsoleMenuHeading>();

        /// <summary>
        /// Executed before each interaction.
        /// </summary>
        private Action customAction = null;
        private int optionsIndex = 0;

        public ConsoleMenu() {
            this.options = new List<ConsoleMenuOption>();
        }

        public ConsoleMenu(List<ConsoleMenuOption> options) {
            this.options = options;
        }

        private string GetMenuText() {
            string buf = "";
            for (int i = 0; i < this.options.Count; i++) {
                buf += this.options[i].Label + ") " + this.options[i].Description + "\n";
                
                // Display a header after this option
                if (this.headings.ContainsKey(i)) {
                    buf += "\n";
                    string heading = this.headings[i].Description;
                    if (heading != null) {
                        buf += heading + "\n";
                    }
                }
            }
            return buf;
        }

        public ConsoleMenu AddOption(string description, Action<ConsoleMenuCommand> callback = null, string customLabel = null) {
            if (customLabel == null) {
                this.optionsIndex++;
                customLabel = this.optionsIndex.ToString();
            }
            ConsoleMenuOption option = new ConsoleMenuOption(customLabel, description, callback);
            this.optionsMap[customLabel] = option;
            this.options.Add(option);
            return this;
        }

        public ConsoleMenu AddExitOption(string description, Action<ConsoleMenuCommand> callback = null) {
            // Overload callback with exit instruction and custom label
            return AddOption(description, (cmd) => {
                callback?.Invoke(cmd);
                cmd.Exit();
            }, "0");
        }

        public ConsoleMenu AddHeading(string description = null, int after = -1) {
            if (after < 0) {
                after = this.options.Count - 1;
            }
            this.headings[after] = new ConsoleMenuHeading(description);
            return this;
        }

        /// <summary>
        /// Executed before each interaction, and before the menu is displayed.
        /// </summary>
        public ConsoleMenu BeforeInteraction(Action callback) {
            this.customAction = callback;
            return this;
        }

        /// <summary>
        /// Displays the menu
        /// </summary>
        public void Display() {
            Console.WriteLine(GetMenuText());
        }

        /// <summary>
        /// Asks for user input to execute the callback. Returns <i>true</i> if the user intends to exit.
        /// </summary>
        public int AskInput() {
            Console.Write("Enter your option: ");
            if (!int.TryParse(Console.ReadLine(), out var option)) {
                Console.WriteLine("Invalid option");
                return -1;
            }

            if (option > 0 && option <= this.options.Count) {
                ConsoleMenuOption consoleOpt = this.options[option - 1];
                // Print the option the user picked
                Console.WriteLine("Option " + option + ". " + consoleOpt.Description);
                Console.WriteLine(new string('-', 26));
                // Run the action
                if (consoleOpt.Callback != null) {
                    ConsoleMenuCommand cmd = new ConsoleMenuCommand();
                    consoleOpt.Callback(cmd);
                }
            }

            return option;
        }

        /// <summary>
        /// Blockingly displays the menu and asks for user input until a signal is sent to exit.
        /// </summary>
        public void DisplayInteraction() {
            while (true) {
                this.customAction();
                this.Display();

                Console.Write("Enter your option: ");
                string option = Console.ReadLine().Trim();

                if (!this.optionsMap.ContainsKey(option)) {
                    Console.WriteLine("Invalid option");
                    goto next;
                }

                ConsoleMenuOption consoleOpt = this.optionsMap[option];
                // Print the option the user picked
                Console.WriteLine("Option " + option + ". " + consoleOpt.Description);
                Console.WriteLine(new string('-', 26));

                // Run the action
                ConsoleMenuCommand cmd = new ConsoleMenuCommand();
                consoleOpt.Callback?.Invoke(cmd);

                // Exit after this if signalled
                if (cmd.ExitNext) {
                    break;
                }

            next:
                Console.WriteLine();
            }
        }
    }
}
