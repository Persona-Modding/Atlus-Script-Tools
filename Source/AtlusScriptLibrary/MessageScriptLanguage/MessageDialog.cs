using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AtlusScriptLibrary.MessageScriptLanguage;

/// <summary>
/// Represents a dialog window in a message script.
/// </summary>
public sealed class MessageDialog : IDialog, IEquatable<MessageDialog>
{
    /// <summary>
    /// Gets the text identifier of this dialog window.
    /// </summary>
    //public string Name { get; set; }

    /// <summary>
    /// Gets or sets the speaker of this dialog window.
    /// </summary>
    public ISpeaker Speaker { get; set; }

    /// <summary>
    /// Gets the pages contained in this dialog window.
    /// </summary>
    public List<TokenText> Pages { get; }

    public override List<TokenText> Lines => Pages;

    /// <summary>
    /// Constructs a new dialog window with just an identifier.
    /// </summary>
    /// <param name="identifier">The identifier of the window.</param>
    public MessageDialog(string identifier)
    {
        Name = identifier ?? throw new ArgumentNullException(nameof(identifier));
        Speaker = null;
        Pages = new List<TokenText>();
    }

    /// <summary>
    /// Constructs a new dialog window with an identifier and a speaker.
    /// </summary>
    /// <param name="identifier">The identifier of the window.</param>
    /// <param name="speaker">The speaker of the window.</param>
    public MessageDialog(string identifier, ISpeaker speaker)
    {
        Name = identifier ?? throw new ArgumentNullException(nameof(identifier));
        Speaker = speaker;
        Pages = new List<TokenText>();
    }

    /// <summary>
    /// Constructs a new dialog window with an identifier, a speaker and a list of lines.
    /// </summary>
    /// <param name="identifier">The identifier of the window.</param>
    /// <param name="speaker">The speaker of the window.</param>
    /// <param name="lines">The list of lines of the window.</param>
    public MessageDialog(string identifier, ISpeaker speaker, List<TokenText> lines)
    {
        Name = identifier ?? throw new ArgumentNullException(nameof(identifier));
        Speaker = speaker;
        Pages = lines ?? throw new ArgumentNullException(nameof(lines));
    }

    /// <summary>
    /// Constructs a new dialog window with an identifier and a list of lines.
    /// </summary>
    /// <param name="identifier">The identifier of the window.</param>
    /// <param name="pages">The list of lines of the window.</param>
    public MessageDialog(string identifier, List<TokenText> pages)
    {
        Name = identifier ?? throw new ArgumentNullException(nameof(identifier));
        Speaker = null;
        Pages = pages;
    }

    /// <summary>
    /// Constructs a new dialog window with an identifier, a speaker and a list of lines.
    /// </summary>
    /// <param name="identifier">The identifier of the window.</param>
    /// <param name="speaker">The speaker of the window.</param>
    /// <param name="lines">The list of lines of the window.</param>
    public MessageDialog(string identifier, ISpeaker speaker, params TokenText[] lines)
    {
        Name = identifier ?? throw new ArgumentNullException(nameof(identifier));
        Speaker = speaker;
        Pages = lines.ToList();
    }

    /// <summary>
    /// Constructs a new dialog window with an identifier and a list of lines.
    /// </summary>
    /// <param name="identifier">The identifier of the window.</param>
    /// <param name="lines">The list of lines of the window.</param>
    public MessageDialog(string identifier, params TokenText[] lines)
    {
        Name = identifier ?? throw new ArgumentNullException(nameof(identifier));
        Speaker = null;
        Pages = lines.ToList();
    }

    /// <summary>
    /// Converts this window to its string representation.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"dlg {Name} {Speaker}";
    }

    /// <summary>
    /// Gets the message type of this window.
    /// </summary>
    public override DialogKind Kind => DialogKind.Message;

    public override IEnumerator<TokenText> GetEnumerator()
    {
        return Pages.GetEnumerator();
    }

    /*IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }*/

    public bool Equals(MessageDialog obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is null) return false;

        if (Name != obj.Name) return false;
        if (Speaker != obj.Speaker) return false;
        return (Pages.SequenceEqual(obj.Pages));
    }

    /*public bool Equals(IDialog obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is null || obj.Kind != DialogKind.Message) return false;

        return Equals((MessageDialog)obj);
    }*/

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is null || obj is not MessageDialog) return false;

        return Equals((MessageDialog)obj);
    }

    public static bool Equals(MessageDialog x, MessageDialog y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null) return false;
        return x.Equals(y);
    }

    public override int GetHashCode()
    {
        int hashCode = 1327504663;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
        hashCode = hashCode * -1521134295 + EqualityComparer<ISpeaker>.Default.GetHashCode(Speaker);
        hashCode = hashCode * -1521134295 + EqualityComparer<List<TokenText>>.Default.GetHashCode(Pages);
        return hashCode;
    }

    public static bool operator ==(MessageDialog x, MessageDialog y) => Equals(x, y);
    public static bool operator !=(MessageDialog x, MessageDialog y) => !Equals(x, y);

    /*public static bool operator ==(MessageDialog x, IDialog y) => x.Equals(y);
    public static bool operator !=(MessageDialog x, IDialog y) => !x.Equals(y);

    public static bool operator ==(IDialog x, MessageDialog y) => y.Equals(x);
    public static bool operator !=(IDialog x, MessageDialog y) => !y.Equals(x);*/
}