using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoggoth : Creature
{


    private void Awake()
    {
        this.Name = "Shoggoth";
        this.form = Form.normal;
        this.maxHP = 100;
        this.Dfn = 5;
        this.Atk = 20;
        this.HP = this.maxHP;
        this.skills = new List<Skills>();
        this.skills.Add(new Attack());
    }
}
