using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Justice : Arcana
{
    /* From Arcana:
    protected string name;
    protected int id;
    protected int level;
    protected int exp;
    protected int totalHP;
    protected int curHP;
    protected float atk;
    protected float magAtk;
    protected float def;
    protected float magDef;
    protected float speed;
    */



    public Justice()
    {
        name = "Justice";
        id = (int)Game.Tarot.Justice;

        level = exp = totalHP = curHP = 0;  
        atk = magAtk = def = magDef = speed = 0f;
    }

    private void Awake()
    {
        /*this.Name = "Justice";
        this.form = Form.upright;
        this.maxHP = 100;
        this.Dfn = 10;
        this.Atk = 10;
        this.HP = this.maxHP;
        this.skills = new List<Skills>();
        this.skills.Add(new Attack());
        this.skills.Add(new ScalesOfJustice());
        this.skills.Add(new ReversalJustice());
        Debug.Log("Skills: " + this.skills.ToString());*/
        
    }
    protected override int generateHP(int lvl)
    {
        return (10 * lvl) + 100;
    }

    protected override float generateAtk(int lvl)
    {
        return (5 * lvl) + 20;
    }
    protected override float generateMagAtk(int lvl)
    {
        return (2 * lvl) + 15;
    }

    protected override float generateDef(int lvl)
    {
        return (4 * lvl) + 20;
    }

    protected override float generateMagDef(int lvl)
    {
        return (2 * lvl) + 15;
    }

    protected override float generateSpeed(int lvl)
    {
        return (3 * lvl) + 15;
    }
}
