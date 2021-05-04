using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skills
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public abstract void DoCombat(Creature owner, Creature target);
}


public class Attack : Skills
{
    public Attack()
    {
        Name = "Attack";
        Desc = "The most basic of skills. Deal Damage equal to you Attack + random value range";
    }

    override public void DoCombat(Creature owner, Creature target = null)
    {
        target.TakeDamage(owner.Atk + ((int)Random.Range(1, 11)));
    }
}
public class ScalesOfJustice : Skills
{
    public ScalesOfJustice()
    {
        Name = "Scales of Justice";
        Desc = "Balance the scales of Fate by Healing yourself for 40 HP";
    }

    override public void DoCombat(Creature owner, Creature target = null)
    {
       owner.Heal(40);
    }
}

public class ReversalJustice : Skills
{
    public ReversalJustice()
    {
        Name = "Reversal";
        Desc = "Sacrifice Defense for Massive Attack Boost, or Return to Normal";
    }

    public override void DoCombat(Creature owner, Creature target = null)
    {
        if (owner.form == Creature.Form.upright)
        {
            owner.form = Creature.Form.reveral;

            owner.Dfn = -5;

            owner.Atk = 40;
        }
        else
        {
            owner.form = Creature.Form.reveral;

            owner.Dfn = 10;

            owner.Atk = 10;
        }
    }
}
