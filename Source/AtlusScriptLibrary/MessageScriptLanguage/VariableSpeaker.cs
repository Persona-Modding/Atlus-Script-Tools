using System;

namespace AtlusScriptLibrary.MessageScriptLanguage;

public sealed class VariableSpeaker : ISpeaker, IEquatable<VariableSpeaker>
{
    /// <summary>
    /// Gets the index of the speaker name variable.
    /// </summary>
    public int Index { get; }

    /// <summary>
    /// Constructs a new variable speaker.
    /// </summary>
    /// <param name="index">The index of the speaker name variable.</param>
    public VariableSpeaker(int index)
    {
        Index = index;
    }

    /// <summary>
    /// Converts this speaker to its string representation.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"<variable name {Index}>";
    }

    public bool Equals(VariableSpeaker other) => Index == other.Index;

    public override int GetHashCode()
    {
        int hashCode = -1061823130;
        hashCode = hashCode * -1521134295 + Index.GetHashCode();
        hashCode = hashCode * -1521134295 + Kind.GetHashCode();
        return hashCode;
    }

    /// <summary>
    /// Gets the speaker type.
    /// </summary>
    public override SpeakerKind Kind => SpeakerKind.Variable;
}