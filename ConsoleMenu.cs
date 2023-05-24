namespace ConsoleMenu;

using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Represents a <see cref="ConsoleMenu"/>
/// </summary>
public sealed class ConsoleMenu
{
    private readonly string? _renderedTitle;

    /// <summary>
    /// Title of this instance, <see langword="null"/> if no title should be shown
    /// </summary>
    public ConsoleMenuTitle? Title { get; }

    /// <summary>
    /// Background color of this instance, <see langword="null"/> if the standard background color should be used
    /// </summary>
    public ConsoleColor? Background { get; }

    /// <summary>
    /// Foreground color of this instance, <see langword="null"/> if the standard foreground color should be used
    /// </summary>
    public ConsoleColor? Foreground { get; }

    /// <summary>
    /// Symbol of this instance
    /// </summary>
    public string Symbol { get; }

    public ConsoleMenu(ConsoleMenuTitle? title, ConsoleColor? background, ConsoleColor? foreground, string symbol)
    {
        Title = title;
        Background = background;
        Foreground = foreground;
        Symbol = symbol;

        _renderedTitle =
            Title is null
            ? null : Title.Font is null
            ? Title.Text : Title.Font.Render(Title.Text);
    }

    public ConsoleMenu(ConsoleMenuConfig config)
        : this(config.Title, config.Background, config.Foreground, config.Symbol) { }

    /// <summary>
    /// Create a <see cref="ConsoleMenu"/> instance
    /// </summary>
    /// <param name="config">The configuration to use</param>
    /// <returns><see cref="ConsoleMenu"/></returns>
    public static ConsoleMenu Create(Action<ConsoleMenuConfig> config)
    {
        ConsoleMenuConfig invoked = new(null, null, null, "");
        config.Invoke(invoked);
        return new(invoked);
    }

    /// <summary>
    /// Runs the Menu with the given <see cref="MenuOption"/>s
    /// </summary>
    /// <param name="options">The <see cref="MenuOption"/>s to run the menu with</param>
    /// <returns><see cref="MenuOption"/></returns>
    public MenuOption Run(params MenuOption[] options)
        => Run(options.AsSpan());

    /// <summary>
    /// Runs the Menu with the given <see cref="MenuOption"/>s
    /// </summary>
    /// <param name="options">The <see cref="MenuOption"/>s to run the menu with</param>
    /// <returns><see cref="MenuOption"/></returns>
    [SuppressMessage("Interoperability", "CA1416:Plattformkompatibilität überprüfen", Justification = "<Ausstehend>")]
    public MenuOption Run(in ReadOnlySpan<MenuOption> options)
    {
        bool cursorVisible = true;

#if WINDOWS
        cursorVisible = Console.CursorVisible;
#endif

        Console.CursorVisible = false;

        var index = 0;

        Draw(in options, options[index]);

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
                        Draw(in options, options[index]);
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (index > 0)
                    {
                        index--;
                        Draw(in options, options[index]);
                    }
                    break;
            }
        } while (key is not ConsoleKey.Enter);

        Console.Clear();
        options[index].Action.Invoke();

        Console.CursorVisible = cursorVisible;

        return options[index];
    }

    private void Draw(in ReadOnlySpan<MenuOption> options, MenuOption selected)
    {
        Console.Clear();

        if (_renderedTitle is not null)
            WriteLineColored(_renderedTitle, Title!.Background, Title!.Foreground);

        foreach (var option in options)
        {
            if (option == selected) WriteColored(Symbol, Background, Foreground);
            else WriteColored(" ", Background, Foreground);

            WriteLineColored(option.Name, option.Background, option.Foreground);
        }
    }

    private static void WriteColored(string text, ConsoleColor? background, ConsoleColor? foreground)
    {
        var bg = Console.BackgroundColor;
        var fg = Console.ForegroundColor;

        Console.BackgroundColor = background ?? bg;
        Console.ForegroundColor = foreground ?? fg;

        Console.Write(text);

        Console.BackgroundColor = bg;
        Console.ForegroundColor = fg;
    }

    private static void WriteLineColored(string text, ConsoleColor? background, ConsoleColor? foreground)
    {
        var bg = Console.BackgroundColor;
        var fg = Console.ForegroundColor;

        Console.BackgroundColor = background ?? bg;
        Console.ForegroundColor = foreground ?? fg;

        Console.WriteLine(text);

        Console.BackgroundColor = bg;
        Console.ForegroundColor = fg;
    }
}