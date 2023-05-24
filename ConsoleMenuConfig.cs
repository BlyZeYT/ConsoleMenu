namespace ConsoleMenu;

/// <summary>
/// Represents the configuration for a <see cref="ConsoleMenu"/>
/// </summary>
public sealed record ConsoleMenuConfig
{
    /// <summary>
    /// Title of the <see cref="ConsoleMenu"/>, <see langword="null"/> if no title should be shown
    /// </summary>
    public ConsoleMenuTitle? Title { get; set; }

    /// <summary>
    /// Background color of the <see cref="ConsoleMenu"/>, <see langword="null"/> if the standard background color should be used
    /// </summary>
    public ConsoleColor? Background { get; set; }

    /// <summary>
    /// Foreground color of the <see cref="ConsoleMenu"/>, <see langword="null"/> if the standard foreground color should be used
    /// </summary>
    public ConsoleColor? Foreground { get; set; }

    /// <summary>
    /// Symbol of the <see cref="ConsoleMenu"/>
    /// </summary>
    public string Symbol { get; set; }

    public ConsoleMenuConfig(
        ConsoleMenuTitle? title,
        ConsoleColor? background,
        ConsoleColor? foreground,
        string symbol)
    {
        Title = title;
        Background = background;
        Foreground = foreground;
        Symbol = symbol;
    }
}