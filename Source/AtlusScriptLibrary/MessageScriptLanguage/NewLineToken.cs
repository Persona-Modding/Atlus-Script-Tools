using System;

namespace AtlusScriptLibrary.MessageScriptLanguage;

/// <summary>
/// Represents a single newline token.
/// </summary>
public class NewLineToken : IToken, IEquatable<NewLineToken>
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

    public bool Equals(NewLineToken other) => true;
    public override bool Equals(object obj) => obj is TokenKind.NewLine;
    public override int GetHashCode() => Kind.GetHashCode();

    public static bool operator ==(NewLineToken x, NewLineToken y) => x.Equals(y);
    public static bool operator !=(NewLineToken x, NewLineToken y) => !x.Equals(y);
}
