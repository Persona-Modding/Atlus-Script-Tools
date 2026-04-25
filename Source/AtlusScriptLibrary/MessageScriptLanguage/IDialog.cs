using System;
using System.Collections;
using System.Collections.Generic;

namespace AtlusScriptLibrary.MessageScriptLanguage;

/// <summary>
/// Common interface for message script dialog windows.
/// </summary>
public abstract class IDialog : IEnumerable<TokenText>, IEquatable<IDialog>
{
    /// <summary>
    /// Gets the dialog type of this dialog.
    /// </summary>
    public abstract DialogKind Kind { get; }

    /// <summary>
    /// Gets the name of this dialog.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets the list of lines contained in this dialog.
    /// </summary>
    public abstract List<TokenText> Lines { get; }

    public bool Equals(IDialog other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (other is null || this.Kind != other.Kind) return false;

        switch (Kind)
        {
            case DialogKind.Message:
                return ((MessageDialog)this).Equals(other as MessageDialog);
            case DialogKind.Selection:
                return ((SelectionDialog)this).Equals(other as SelectionDialog);
            default:
                throw new Exception("Invalid dialog kind");
        }
    }

    public override bool Equals(object obj) => Equals(obj as IDialog);
    public static bool Equals(IDialog x, IDialog y)
    {
        if (ReferenceEquals (x, y)) return true;
        if (x is null || y is null) return false;
        return x.Equals (y);
    }

    public abstract IEnumerator<TokenText> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override int GetHashCode()
    {
        int hashCode = -1358287131;
        hashCode = hashCode * -1521134295 + Kind.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
        hashCode = hashCode * -1521134295 + EqualityComparer<List<TokenText>>.Default.GetHashCode(Lines);
        return hashCode;
    }

    public static bool operator==(IDialog x, IDialog y) => Equals(x, y);
    public static bool operator!=(IDialog x, IDialog y) => !Equals(x, y);
}

/*public class DialogComparer : EqualityComparer<IDialog>
{
    public override bool Equals(IDialog x, IDialog y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null || x.Kind != y.Kind) return false;

        switch (x.Kind)
        {
            case DialogKind.Message:
                return ((MessageDialog)x).Equals((MessageDialog)y);
            case DialogKind.Selection:
                return ((SelectionDialog)x).Equals((SelectionDialog)y);
            default:
                throw new Exception("Invalid dialog kind");
        }
    }

    public override int GetHashCode(IDialog obj)
    {
        switch (obj.Kind)
        {
            case DialogKind.Message:
                return ((MessageDialog)obj).GetHashCode();
            case DialogKind.Selection:
                return ((SelectionDialog)obj).GetHashCode();
            default:
                throw new Exception("Invalid dialog kind");
        }
    }
}*/