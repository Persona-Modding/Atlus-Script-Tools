using System;
using System.Collections.Generic;

namespace AtlusScriptLibrary.MessageScriptLanguage;

/// <summary>
/// Represents a message script value token.
/// </summary>
public struct StringToken : IToken, IEquatable<StringToken>
{
    /// <summary>
    /// Gets the value contained by this token. This can be a single word or a whole sentence.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Constructs a new message script value token with a value value.
    /// </summary>
    /// <param name="value">The value value of the value token/</param>
    public StringToken(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Converts this token to its string representation.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Value;
    }

    /// <summary>
    /// Gets the token type.
    /// </summary>
    TokenKind IToken.Kind => TokenKind.String;

    public bool Equals(StringToken other) => Value == other.Value;
    public override bool Equals(object obj)
    {
        if (obj is null || obj is not StringToken) return false;
        return Equals((StringToken)obj);
    }

    public override int GetHashCode() => Value.GetHashCode();
}
