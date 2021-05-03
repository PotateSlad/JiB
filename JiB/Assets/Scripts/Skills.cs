using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skills
{
    string Name { get; set; }
    string Desc { get; set; }
    void doCombat(Creature owner, List<Creature> enemies, Creature target)
    {
        return;
    }
}

public class ScalesOfJustice : Skills
{
    public string Name = "Scales of Justice";
    public string Desc = "Balanec the scales of Fate by Healing yourself for 20 HP";

    public void doCombat(Creature owner, List<Creature> enemies, Creature target)
    {
       target.TakeDamage(-20);
    }
}
