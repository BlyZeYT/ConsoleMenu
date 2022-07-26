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
        /// Initializes a Console Menu without a title
        /// </summary>
        /// <param name="menuColor">The color of the menu</param>
        /// <param name="menuSymbol">The symbol of the menu</param>
        public ConsoleMenuSimple(MenuColor menuColor, string menuSymbol = ">")
        {
            this.menuColor = menuColor.Color;
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
        /// Initializes a Console Menu with a title
        /// </summary>
        /// <param name="menuColor">The color of the menu</param>
        /// <param name="title">The title of the menu</param>
        /// <param name="titleColor">The color of the title menu</param>
        /// <param name="menuSymbol">The symbol of the menu</param>
        public ConsoleMenu(MenuColor menuColor, string title, MenuColor titleColor, string menuSymbol = ">")
        {
            this.menuColor = menuColor.Color;
            this.title = title;
            this.titleColor = titleColor.Color;
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
        /// Initializes a Console Menu with an Ascii Title
        /// </summary>
        /// <param name="menuColor">The color of the menu</param>
        /// <param name="title">The title of the menu</param>
        /// <param name="titleColor">The color of the menu title</param>
        /// <param name="menuSymbol">The menu symbol</param>
        /// <param name="fontPath">The path of the ascii font</param>
        public ConsoleMenuAscii(MenuColor menuColor, string title, MenuColor titleColor, string menuSymbol = ">", string fontPath = "")
        {
            this.menuColor = menuColor.Color;
            this.title = title;
            this.titleColor = titleColor.Color;
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
    /// Represents a Menu Option
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

        /// <summary>
        /// Creates a new Menu Option
        /// </summary>
        /// <param name="name">The name of the option</param>
        /// <param name="color">The color of the option</param>
        /// <param name="action">The action that should be invoked</param>
        public MenuOption(string name, MenuColor color, Action action)
        {
            Name = name;
            Color = color.Color;
            Action = action;
        }
    }

    /// <summary>
    /// Represents a Menu Color
    /// </summary>
    public readonly struct MenuColor
    {
        private readonly Color color;
        /// <summary>
        /// Gets the <see cref="System.Drawing.Color"/> of the <see cref="MenuColor"/>
        /// </summary>
        public Color Color { get { return color; } }

        /// <summary>
        /// Initializes a Menu Color
        /// </summary>
        /// <param name="color">The color to create a Menu Color as <see cref="System.Drawing.Color"/></param>
        public MenuColor(Color color)
        {
            this.color = color;
        }

        /// <summary>
        /// Initializes a Menu Color
        /// </summary>
        /// <param name="hexValue">The color to create a Menu Color as HEX <see cref="string"/></param>
        /// <exception cref="Exception"></exception>
        public MenuColor(string HEXValue)
        {
            try
            {
                color = ColorTranslator.FromHtml(HEXValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Initializes a Menu Color
        /// </summary>
        /// <param name="red">Red value</param>
        /// <param name="green">Green value</param>
        /// <param name="blue">Blue value</param>
        public MenuColor(byte red, byte green, byte blue)
        {
            color = Color.FromArgb(red, green, blue);
        }

        /// <summary>
        /// Initializes a Menu Color
        /// </summary>
        /// <param name="alpha">Alpha value</param>
        /// <param name="red">Red value</param>
        /// <param name="green">Green value</param>
        /// <param name="blue">Blue value</param>
        public MenuColor(byte alpha, byte red, byte green, byte blue)
        {
            color = Color.FromArgb(alpha, red, green, blue);
        }

        /// <summary>
        /// Gets the color from a red, green and blue value
        /// </summary>
        /// <param name="red">Red value</param>
        /// <param name="green">Green value</param>
        /// <param name="blue">Blue value</param>
        /// <returns>Returns a <see cref="System.Drawing.Color"/> from a red, green and blue value</returns>
        public static Color FromArgb(byte red, byte green, byte blue) => Color.FromArgb(red, green, blue);

        /// <summary>
        /// Gets the color from an alpha, red, green and blue value
        /// </summary>
        /// <param name="alpha">Alpha value</param>
        /// <param name="red">Red value</param>
        /// <param name="green">Green value</param>
        /// <param name="blue">Blue value</param>
        /// <returns>Returns a <see cref="System.Drawing.Color"/> from an alpha, red, green and blue value</returns>
        public static Color FromArgb(byte alpha, byte red, byte green, byte blue) => Color.FromArgb(alpha, red, green, blue);

        /// <summary>
        /// Gets the color from a HEX value
        /// </summary>
        /// <param name="HEXValue">The HEX value as <see cref="string"/></param>
        /// <returns>Returns a <see cref="System.Drawing.Color"/> from HEX <see cref="string"/></returns>
        /// <exception cref="Exception"></exception>
        public static Color FromHEX(string HEXValue)
        {
            try
            {
                return ColorTranslator.FromHtml(HEXValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static implicit operator Color(MenuColor menuColor) => menuColor.Color;
        public static explicit operator MenuColor(Color color) => new(color);
    }
}
