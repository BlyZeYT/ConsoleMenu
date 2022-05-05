# ConsoleMenu
## For .NET 6.0
Easy to use and highly customizable Console Menu

### Documentation

> Create a ConsoleMenu object

    var menu = new ConsoleMenu(Color.Red, "Title", Color.FromArgb(255, 255, 255), "->"); //Simple Menu
    var menuAscii = new ConsoleMenuAscii(Color.Red, "Title", Color.FromArgb(255, 255, 255), "->"); //Fancy Menu

> Create an array of the MenuOption object

    var options = new MenuOption[]
          {
              new MenuOption("Option 1", Color.Green, () => Main()), //Starts Main() Method when chosen
              new MenuOption("Option 2", Color.HotPink, () => Console.Beep(25000, 100000)) //Plays Beep Sound when chosen (Beep() Method only on Windows avalable)
          };

> Run the ConsoleMenu with the options array as parameter

    menu.Run(options);
