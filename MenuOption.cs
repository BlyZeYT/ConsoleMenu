namespace ConsoleMenu;

/// <summary>
/// Represents an option for <see cref="ConsoleMenu"/>
/// </summary>
public sealed record MenuOption
{
    /// <summary>
    /// Name that should be shown
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Background color, <see langword="null"/> if the standard background color should be used
    /// </summary>
    public ConsoleColor? Background { get; }

    /// <summary>
    /// Foreground color, <see langword="null"/> if the standard foreground color should be used
    /// </summary>
    public ConsoleColor? Foreground { get; }

    /// <summary>
    /// Action that should be invoked
    /// </summary>
    public Action Action { get; }

    public MenuOption(string name, ConsoleColor? background, ConsoleColor? foreground, Action action)
    {
        Name = name;
        Background = background;
        Foreground = foreground;
        Action = action;
    }
}