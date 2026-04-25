using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AtlusScriptLibrary.MessageScriptLanguage;

/// <summary>
/// Represents a selection window in a message script.
/// </summary>
public sealed class SelectionDialog : IDialog, IEquatable<SelectionDialog>
{
    /// <summary>
    /// Gets the text identifier of this dialog.
    /// </summary>
    //public string Name { get; set; }

    /// <summary>
    /// Gets or sets the selection pattern of the dialog.
    /// </summary>
    public SelectionDialogPattern Pattern { get; set; }

    /// <summary>
    /// Gets the options contained in this selection dialog.
    /// </summary>
    public List<TokenText> Options { get; }

    public override List<TokenText> Lines => Options;

    /// <summary>
    /// Constructs a new selection dialog with just an identifier.
    /// </summary>
    /// <param name="identifier">The text identifier of the window.</param>
    public SelectionDialog(string identifier, SelectionDialogPattern pattern = SelectionDialogPattern.Top)
    {
        Name = identifier;
        Pattern = pattern;
        Options = new List<TokenText>();
    }

    /// <summary>
    /// Constructs a new selection dialog with just an identifier.
    /// </summary>
    /// <param name="identifier">The text identifier of the dialog.</param>
    /// <param name="pages">The list of lines in the dialog.</param>
    public SelectionDialog(string identifier, SelectionDialogPattern pattern, List<TokenText> pages)
    {
        Name = identifier;
        Pattern = pattern;
        Options = pages;
    }

    /// <summary>
    /// Constructs a new selection dialog with just an identifier.
    /// </summary>
    /// <param name="identifier">The text identifier of the dialog.</param>
    /// <param name="pages">The list of lines in the dialog.</param>
    public SelectionDialog(string identifier, SelectionDialogPattern pattern, params TokenText[] pages)
    {
        Name = identifier;
        Pattern = pattern;
        Options = pages.ToList();
    }

    /// <summary>
    /// Gets the dialog type.
    /// </summary>
    public override DialogKind Kind => DialogKind.Selection;

    public override IEnumerator<TokenText> GetEnumerator()
    {
        return Options.GetEnumerator();
    }

    /*IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }*/

    public bool Equals(SelectionDialog obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is null) { return false; }

        if (Name != obj.Name) return false;
        if (Pattern != obj.Pattern) return false;
        return (Options.SequenceEqual(obj.Options));
    }

    /*public bool Equals(IDialog obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is null || obj.Kind != DialogKind.Selection) return false;

        return Equals((SelectionDialog)obj);
    }*/

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is null || obj is not SelectionDialog) return false;

        return Equals((SelectionDialog)obj);
    }

    public static bool Equals(SelectionDialog x, SelectionDialog y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null) return false;
        return x.Equals(y);
    }

    public override int GetHashCode()
    {
        int hashCode = -95244068;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
        hashCode = hashCode * -1521134295 + Pattern.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<List<TokenText>>.Default.GetHashCode(Options);
        return hashCode;
    }

    public static bool operator ==(SelectionDialog x, SelectionDialog y) => Equals(x, y);
    public static bool operator !=(SelectionDialog x, SelectionDialog y) => !Equals(x, y);

    /*public static bool operator ==(SelectionDialog x, IDialog y) => x.Equals(y);
    public static bool operator !=(SelectionDialog x, IDialog y) => !x.Equals(y);

    public static bool operator ==(IDialog x, SelectionDialog y) => y.Equals(x);
    public static bool operator !=(IDialog x, SelectionDialog y) => !y.Equals(x);*/
}