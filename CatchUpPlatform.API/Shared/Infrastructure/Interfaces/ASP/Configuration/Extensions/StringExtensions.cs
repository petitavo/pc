using System.Text.RegularExpressions;

namespace CatchUpPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/// <summary>
/// Extension methods for <see cref="string"/>. 
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Converts the text to kebab case. 
    /// </summary>
    /// <param name="text">string to convert</param>
    /// <returns>
    /// The kebab case string. 
    /// </returns>
    public static string ToKebabCase(this string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;
        return KebabCaseRegex().Replace(text, "-$1")
            .Trim()
            .ToLower();
    }

    [GeneratedRegex("[a-z0-9]+(?:-[a-z0-9]+)*", RegexOptions.Compiled)]
    private static partial Regex KebabCaseRegex();
}