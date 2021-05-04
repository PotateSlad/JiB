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

    override public void DoCombat(Creature owner, Creature target)
    {
        target.TakeDamage(owner.Atk + ((int)Random.Range(1, 11)));
    }
}
public class ScalesOfJustice : Skills
{
    public ScalesOfJustice()
    {
        Name = "Scales of Justice";
        Desc = "Balance the scales of Fate by Healing yourself for 20 HP";
    }

    override public void DoCombat(Creature owner, Creature target)
    {
       target.Heal(20);
    }
}
