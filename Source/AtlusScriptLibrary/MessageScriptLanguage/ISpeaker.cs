using System;
namespace AtlusScriptLibrary.MessageScriptLanguage;

/// <summary>
/// Common interface for dialogue message speakers.
/// </summary>
public abstract class ISpeaker : IEquatable<ISpeaker>
{
    /// <summary>
    /// Gets the speaker type.
    /// </summary>
    public abstract SpeakerKind Kind { get; }

    public bool Equals(ISpeaker other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (other is null || other.Kind != Kind) return false;

        switch (Kind)
        {
            case SpeakerKind.Named:
                return ((NamedSpeaker)this).Equals(other as NamedSpeaker);
            case SpeakerKind.Variable:
                return ((VariableSpeaker)this).Equals(other as VariableSpeaker);
            default:
                throw new Exception("Unrecognized speaker kind");
        }
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is null || obj is not ISpeaker) return false;
        return Equals(obj as ISpeaker);
    }

    public static bool Equals(ISpeaker x, ISpeaker y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null) return false;
        return x.Equals(y);
    }

    public abstract override int GetHashCode();

    public static bool operator==(ISpeaker x, ISpeaker y) => Equals(x, y);
    public static bool operator!=(ISpeaker x, ISpeaker y) => !Equals(x, y);
}