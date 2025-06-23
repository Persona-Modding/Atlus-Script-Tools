using System.Collections.Generic;
using System.Linq;

namespace AtlusScriptLibrary.FlowScriptLanguage;

public class Procedure
{
    public string Name { get; set; }

    public List<Instruction> Instructions { get; }

    public List<Label> Labels { get; }

    public Procedure(string name)
    {
        Name = name;
        Instructions = new List<Instruction>();
        Labels = new List<Label>();
    }

    public Procedure(string name, List<Instruction> instructions)
    {
        Name = name;
        Instructions = instructions;
        Labels = new List<Label>();
    }

    public Procedure(string name, List<Instruction> instructions, List<Label> labels)
    {
        Name = name;
        Instructions = instructions;
        Labels = labels;
    }

    public override string ToString()
    {
        return $"{Name} with {Instructions.Count} instructions";
    }

    public Procedure Clone()
    {
        var p = new Procedure(Name);
        foreach (var i in Instructions)
            p.Instructions.Add(i.Clone());

        foreach (var l in Labels)
            p.Labels.Add(l.Clone());

        return p;
    }

    public bool Equals(Procedure other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (other == null) return false;

        if (Name != other.Name) return false;
        if (!Instructions.SequenceEqual(other.Instructions)) return false;
        return (!Labels.SequenceEqual(other.Labels));
    }

    public static bool operator ==(Procedure x, Procedure y) => x.Equals(y);
    public static bool operator !=(Procedure x, Procedure y) => !x.Equals(y);
}
