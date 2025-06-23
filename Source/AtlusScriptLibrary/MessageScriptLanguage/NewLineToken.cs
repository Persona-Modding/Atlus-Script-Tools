namespace AtlusScriptLibrary.MessageScriptLanguage;

/// <summary>
/// Represents a single newline token.
/// </summary>
public class NewLineToken : IToken
{
    /// <summary>
    /// The constant value of a newline token.
    /// </summary>
    public const byte ASCIIValue = 0x0A;

    /// <summary>
    /// Gets the type of this token.
    /// </summary>
    public TokenKind Kind => TokenKind.NewLine;

    /// <summary>
    /// Converts this token to its string reprentation.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "<new line>";
    }

    public bool Equals(IToken obj) => obj.Kind == TokenKind.NewLine;

    public static bool operator ==(NewLineToken x, NewLineToken y) => x.Equals(y);
    public static bool operator !=(NewLineToken x, NewLineToken y) => !x.Equals(y);
}
