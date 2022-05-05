namespace ConsoleMenu
{
    using Colorful;
    using Console = Colorful.Console;
    using System.Drawing;

    /// <summary>
    /// Initializes a simple Console Menu
    /// </summary>
    public struct ConsoleMenu
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
        /// Return the Menu Symbol
        /// </summary>
        public string MenuSymbol { get { return menuSymbol; } }

        /// <summary>
        /// Initializes a simple Console Menu
        /// </summary>
        /// <param name="menuColor"></param>
        /// <param name="title"></param>
        /// <param name="titleColor"></param>
        /// <param name="menuSymbol"></param>
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
        /// <param name="options"></param>
        public void Run(MenuOption[] options)
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
    }

    /// <summary>
    /// Initializes a simple Console Menu with an Ascii Title
    /// </summary>
    public struct ConsoleMenuAscii
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
        /// Initializes a simple Console Menu with an Ascii Title
        /// </summary>
        /// <param name="menuColor"></param>
        /// <param name="title"></param>
        /// <param name="titleColor"></param>
        /// <param name="menuSymbol"></param>
        /// <param name="fontPath"></param>
        /// <exception Throws an cref="Exception" if the font path is wrong></exception>
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
        /// <param name="options"></param>
        public void Run(MenuOption[] options)
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
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="action"></param>
        public MenuOption(string name, Color color, Action action)
        {
            Name = name;
            Color = color;
            Action = action;
        }
    }
}