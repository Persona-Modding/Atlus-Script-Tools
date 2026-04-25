using System;
using System.Collections.Generic;

namespace AtlusScriptLibrary.MessageScriptLanguage;

/// <summary>
/// Common interface for message script line tokens.
/// </summary>
public interface IToken
{
    /// <summary>
    /// Gets the type of token.
    /// </summary>
    TokenKind Kind { get; }
}

public class TokenComparer : EqualityComparer<IToken>
{
    public override bool Equals(IToken x, IToken y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null || x.Kind != y.Kind) return false;

        switch (x.Kind)
        {
            case TokenKind.NewLine:
                return true;
            case TokenKind.Function:
                return ((FunctionToken)x).Equals((FunctionToken)y);
            case TokenKind.String:
                return ((StringToken)x).Equals((StringToken)y);
            case TokenKind.CodePoint:
                return ((CodePointToken)x).Equals((CodePointToken)y);
            default:
                throw new Exception("Invalid token kind");
        }
    }

    public override int GetHashCode(IToken obj)
    {
        switch (obj.Kind)
        {
            case TokenKind.NewLine:
                return ((NewLineToken)obj).GetHashCode();
            case TokenKind.Function:
                return ((FunctionToken)obj).GetHashCode();
            case TokenKind.String:
                return ((StringToken)obj).GetHashCode();
            case TokenKind.CodePoint:
                return ((CodePointToken)obj).GetHashCode();
            default:
                throw new Exception("Invalid token kind");
        }
    }
}