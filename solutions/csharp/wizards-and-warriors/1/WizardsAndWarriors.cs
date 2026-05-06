abstract class Character
{
    private string _characterType = "";
    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {_characterType}";
}

class Warrior: Character
{        
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable())            
            return 10;            
        return 6;
    }
}

class Wizard : Character
{
    public bool HasPreparedSpell { get; set; } = false;
    public Wizard() : base("Wizard")
    {
    }

    public override bool Vulnerable() => !HasPreparedSpell;

    public override int DamagePoints(Character target)
{
    if (HasPreparedSpell)
    {
        HasPreparedSpell = false;
        return 12;
    }
    return 3;
}

    public void PrepareSpell()
    {
        HasPreparedSpell = true;
    }
}
