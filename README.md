# ConsoleMenu
## For .NET 6.0
Easy to use and highly customizable Console Menu

### Documentation

> Run the ConsoleMenu with the options array as parameter and dispose it afterwards

```
MenuOption chosenOption;
using (var menu = new ConsoleMenu(Color.Red, "MenuTitle", Color.FromArgb(255,22,13), "->"))
{
    menu.Run(new MenuOption[]
    {
        new MenuOption("Option 1", Color.Green, () => Main()),
        new MenuOption("Option 2", Color.Yellow, () => Console.CursorVisible = false)
    }, out chosenOption);
}
```
