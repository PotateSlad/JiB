using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Justice : Creature
{

    private void Awake()
    {
        this.Name = "Justice";
        this.form = Form.upright;
        this.maxHP = 100;
        this.Dfn = 10;
        this.Atk = 10;
        this.HP = this.maxHP;
        this.skills = new List<Skills>();
        this.skills.Add(new Attack());
        this.skills.Add(new ScalesOfJustice());
        this.skills.Add(new ReversalJustice());
        Debug.Log("Skills: " + this.skills.ToString());
        
    }
}
