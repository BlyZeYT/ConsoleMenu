namespace ConsoleMenu;

using Figgle;

/// <summary>
/// Represents the title options for a <see cref="ConsoleMenu"/>
/// </summary>
public sealed record ConsoleMenuTitle
{
    /// <summary>
    /// Title text
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Background color for the title text, <see langword="null"/> if the standard background color should be used
    /// </summary>
    public ConsoleColor? Background { get; set; }

    /// <summary>
    /// Foreground color for the title text, <see langword="null"/> if the standard foreground color should be used
    /// </summary>
    public ConsoleColor? Foreground { get; set; }

    /// <summary>
    /// Ascii font for the title
    /// </summary>
    public FiggleFont? Font { get; set; }

    public ConsoleMenuTitle(string text, ConsoleColor? background, ConsoleColor? foreground, FiggleFont? font)
    {
        Text = text;
        Background = background;
        Foreground = foreground;
        Font = font;
    }

    /// <summary>
    /// Create a <see cref="ConsoleMenuTitle"/> instance
    /// </summary>
    /// <param name="text">Text, that is shown</param>
    /// <param name="background">Background color, <see langword="null"/> if console standard should be used</param>
    /// <param name="foreground">Foreground color, <see langword="null"/> if console standard should be used</param>
    /// <param name="fontPath">Where the figlet font file is located</param>
    /// <returns><see cref="ConsoleMenuTitle"/></returns>
    /// <exception cref="FileNotFoundException"></exception>
    public static ConsoleMenuTitle FromFile(string text, ConsoleColor? background, ConsoleColor? foreground, string? fontPath)
    {
        if (!File.Exists(fontPath))
            throw new FileNotFoundException("The file could not be found", fontPath);

        var consoleMenuTitle = new ConsoleMenuTitle(text, background, foreground, null);

        using (var stream = File.OpenRead(fontPath))
        {
            consoleMenuTitle.Font = FiggleFontParser.Parse(stream);
        }

        return consoleMenuTitle;
    }
}