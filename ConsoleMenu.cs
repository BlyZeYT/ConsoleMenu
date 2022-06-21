namespace ConsoleMenu
{
    using Colorful;
    using Console = Colorful.Console;
    using System.Drawing;

    /// <summary>
    /// Initializes a Console Menu without a title
    /// </summary>
    public struct ConsoleMenuSimple : IDisposable
    {
        private Color menuColor;
        /// <summary>
        /// Returns the Menu Color
        /// </summary>
        public Color MenuColor { get { return menuColor; } }
        private string menuSymbol;
        /// <summary>
        /// Returns the Menu Symbol
        /// </summary>
        public string MenuSymbol { get { return menuSymbol; } }

        /// <summary>
        /// Initializes a Console Menu without a title
        /// </summary>
        /// <param name="menuColor">The color of the menu</param>
        /// <param name="menuSymbol">The symbol of the menu</param>
        public ConsoleMenuSimple(Color menuColor, string menuSymbol = ">")
        {
            this.menuColor = menuColor;
            this.menuSymbol = menuSymbol;
        }

        /// <summary>
        /// Runs the Menu with the given Menu Options
        /// </summary>
        /// <param name="options">The options to run the menu with</param>
        /// <param name="chosenOption">The chosen option</param>
        public void Run(MenuOption[] options, out MenuOption chosenOption)
        {
            var index = 0;

            Draw(menuColor, menuSymbol, options, options[index]);

            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < options.Length - 1)
                        {
                            index++;
                            Draw(menuColor, menuSymbol, options, options[index]);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                        {
                            index--;
                            Draw(menuColor, menuSymbol, options, options[index]);
                        }
                        break;
                }
            } while (key != ConsoleKey.Enter);
            Console.Clear();
            chosenOption = options[index];
            options[index].Action.Invoke();
        }

        private static void Draw(Color menuColor, string menuSymbol, MenuOption[] options, MenuOption selected)
        {
            Console.Clear();

            Console.WriteLine();

            foreach (var option in options)
            {
                if (option == selected)
                {
                    Console.Write(menuSymbol + " ", menuColor);
                }
                else
                {
                    Console.Write("  ", menuColor);
                }

                Console.WriteLine(option.Name, option.Color);
            }
        }

        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// Initializes a Console Menu with a title
    /// </summary>
    public struct ConsoleMenu : IDisposable
    {
        private Color menuColor;
        /// <summary>
        /// Returns the Menu Color
        /// </summary>
        public Color MenuColor { get { return menuColor; } }
        private string title;
        /// <summary>
        /// Returns the Title
        /// </summary>
        public string Title { get { return title; } }
        private Color titleColor;
        /// <summary>
        /// Returns the Title Color
        /// </summary>
        public Color TitleColor { get { return titleColor; } }
        private string menuSymbol;
        /// <summary>
        /// Returns the Menu Symbol
        /// </summary>
        public string MenuSymbol { get { return menuSymbol; } }

        /// <summary>
        /// Initializes a Console Menu with a title
        /// </summary>
        /// <param name="menuColor">The color of the menu</param>
        /// <param name="title">The title of the menu</param>
        /// <param name="titleColor">The color of the title menu</param>
        /// <param name="menuSymbol">The symbol of the menu</param>
        public ConsoleMenu(Color menuColor, string title, Color titleColor, string menuSymbol = ">")
        {
            this.menuColor = menuColor;
            this.title = title;
            this.titleColor = titleColor;
            this.menuSymbol = menuSymbol;
        }

        /// <summary>
        /// Runs the Menu with the given Menu Options
        /// </summary>
        /// <param name="options">The options to run the menu with</param>
        /// <param name="chosenOption">The chosen option</param>
        public void Run(MenuOption[] options, out MenuOption chosenOption)
        {
            var index = 0;

            Draw(menuColor, title, titleColor, menuSymbol, options, options[index]);

            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < options.Length - 1)
                        {
                            index++;
                            Draw(menuColor, title, titleColor, menuSymbol, options, options[index]);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                        {
                            index--;
                            Draw(menuColor, title, titleColor, menuSymbol, options, options[index]);
                        }
                        break;
                }
            } while (key != ConsoleKey.Enter);
            Console.Clear();
            chosenOption = options[index];
            options[index].Action.Invoke();
        }

        private static void Draw(Color menuColor, string title, Color titleColor, string menuSymbol, MenuOption[] options, MenuOption selected)
        {
            Console.Clear();

            Console.WriteLine($"  {title}\n", titleColor);

            foreach (var option in options)
            {
                if (option == selected)
                {
                    Console.Write(menuSymbol + " ", menuColor);
                }
                else
                {
                    Console.Write("  ", menuColor);
                }

                Console.WriteLine(option.Name, option.Color);
            }
        }

        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// Initializes a Console Menu with an Ascii title
    /// </summary>
    public struct ConsoleMenuAscii : IDisposable
    {
        private Color menuColor;
        /// <summary>
        /// Returns the Menu Color
        /// </summary>
        public Color MenuColor { get { return menuColor; } }
        private string title;
        /// <summary>
        /// Returns the Title
        /// </summary>
        public string Title { get { return title; } }
        private Color titleColor;
        /// <summary>
        /// Returns the Title Color
        /// </summary>
        public Color TitleColor { get { return titleColor; } }
        private string menuSymbol;
        /// <summary>
        /// Returns the Menu Symbol
        /// </summary>
        public string MenuSymbol { get { return menuSymbol; } }
        private string fontPath = "";
        /// <summary>
        /// Returns the Font Path
        /// </summary>
        public string FontPath { get { return fontPath; } }
        private Figlet? figlet = null;

        /// <summary>
        /// Initializes a Console Menu with an Ascii Title
        /// </summary>
        /// <param name="menuColor">The color of the menu</param>
        /// <param name="title">The title of the menu</param>
        /// <param name="titleColor">The color of the menu title</param>
        /// <param name="menuSymbol">The menu symbol</param>
        /// <param name="fontPath">The path of the ascii font</param>
        public ConsoleMenuAscii(Color menuColor, string title, Color titleColor, string menuSymbol = ">", string fontPath = "")
        {
            this.menuColor = menuColor;
            this.title = title;
            this.titleColor = titleColor;
            this.menuSymbol = menuSymbol;

            if (fontPath != "")
            {
                try
                {
                    figlet = new Figlet(FigletFont.Load(fontPath));
                    this.fontPath = fontPath;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
        }

        /// <summary>
        /// Runs the Menu with the given Menu Options
        /// </summary>
        /// <param name="options">The options to run the menu with</param>
        /// <param name="chosenOption">The chosen option</param>
        public void Run(MenuOption[] options, out MenuOption chosenOption)
        {
            var index = 0;

            Draw(menuColor, title, titleColor, menuSymbol, options, options[index], figlet);

            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < options.Length - 1)
                        {
                            index++;
                            Draw(menuColor, title, titleColor, menuSymbol, options, options[index], figlet);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                        {
                            index--;
                            Draw(menuColor, title, titleColor, menuSymbol, options, options[index], figlet);
                        }
                        break;
                }
            } while (key != ConsoleKey.Enter);
            Console.Clear();
            chosenOption = options[index];
            options[index].Action.Invoke();
        }

        private static void Draw(Color menuColor, string title, Color titleColor, string menuSymbol, MenuOption[] options, MenuOption selected, Figlet? font)
        {
            Console.Clear();

            if (font is null)
            {
                Console.WriteAscii(title, titleColor);
            }
            else
            {
                try
                {
                    Console.Write(font.ToAscii(title), titleColor);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message == "" ? ex.ToString() : ex.Message, ex.InnerException);
                }
            }

            foreach (var option in options)
            {
                if (option == selected)
                {
                    Console.Write(menuSymbol + " ", menuColor);
                }
                else
                {
                    Console.Write("  ", menuColor);
                }

                Console.WriteLine(option.Name, option.Color);
            }
        }

        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// Creates a new Menu Option
    /// </summary>
    public class MenuOption
    {
        /// <summary>
        /// Sets the Option Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Sets the Option Color
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// Sets the Option Action
        /// </summary>
        public Action Action { get; set; }

        /// <summary>
        /// Creates a new Menu Option
        /// </summary>
        /// <param name="name">The name of the option</param>
        /// <param name="color">The color of the option</param>
        /// <param name="action">The action that should be invoked</param>
        public MenuOption(string name, Color color, Action action)
        {
            Name = name;
            Color = color;
            Action = action;
        }
    }
}
