abstract class Character
{
    private string characterType;
    protected Character(string characterType)
    {
        this.characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {this.characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable())
        {
            return 10;
        }
        else
        {
            return 6;
        }
    }
}

class Wizard : Character
{
    private bool isSpellPrepared;
    
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (isSpellPrepared)
        {
            return 12;
        }
        else
        {
            return 3;
        }
    }

    public override bool Vulnerable()
    {
        if (isSpellPrepared) return false;
        else return true;
    }

    public void PrepareSpell()
    {
        isSpellPrepared = true;
    }
}
