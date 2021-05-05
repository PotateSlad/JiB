//Reference from https://www.youtube.com/watch?v=XOjd_qU2Ido
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CreatureData
{
    //data we want as public variables in string, bool, float, int
    public string Name;
    public string form;
    public int maxHP;
    public int HP; 
    public int Dfn;
    public int Atk;
    public int skill_count;
    public string[] skills;
    //public List<Skills> skills;

    public CreatureData (Creature creature)
    {
        Name = creature.Name;
        if(creature.form.Equals(Creature.Form.normal))
            form = "normal";
        else if(creature.form.Equals(Creature.Form.upright))
            form = "upright";
        else
            form = "reveral";
        maxHP = creature.maxHP;
        HP = creature.HP;
        Dfn = creature.Dfn;
        Atk = creature.Atk;

        skill_count = creature.skills.Count;
        skills = new string[skill_count];
        int ind = 0;
        foreach (var skill in creature.skills)
        {
            if(skill.Name.Equals("Attack"))
                skills[ind] = "Attack";
            else if(skill.Name.Equals("Scales of Justice"))
                skills[ind] = "Scales of Justice";
            else if(skill.Name.Equals("Reversal"))
                skills[ind] = "Reversal";
            ind++;
        }
    }
}
//End Reference