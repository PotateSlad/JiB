using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arcana
{
    public string name = "";
    protected int id;
    protected int level;
    protected int exp;
    public int totalHP;
    public int curHP;
    public float atk;
    public float magAtk;
    public float def;
    public float magDef;
    public float speed;

    protected List<Skill> skills = new List<Skill>();

    //for leveling up or setting the first time
    public void updateStats(int lvl)
    {
        level = lvl;
        totalHP = generateHP(level);
        //leveling up will heal a character to full HP
        curHP = totalHP;
        atk = generateAtk(level);
        magAtk = generateMagAtk(level);
        def = generateDef(level);
        magDef = generateMagDef(level);
        speed = generateSpeed(level);
    }

    protected abstract int generateHP(int lvl);
    protected abstract float generateAtk(int lvl);
    protected abstract float generateMagAtk(int lvl);
    protected abstract float generateDef(int lvl);
    protected abstract float generateMagDef(int lvl);
    protected abstract float generateSpeed(int lvl);

    public void attack(Monster m)
    {
        //TEMP
        m.curHP -= (int)(atk - m.def);
    }


    public void setExp(int e)
    {
        exp = e;
    }

    public void addExp(int e)
    {
        exp += e;
        int levelUpGoal = (int)(100 + (100 * Mathf.Pow(1.1f, level - 1)));

        //level up if able
        if (exp > levelUpGoal)
        {
            exp -= levelUpGoal;
            updateStats(level + 1);
        }
    }

    public void setLevel(int l)
    {
        updateStats(l);
    }

    public int getLevel()
    {
        return level;
    }

    public int getExp()
    {
        return exp;
    }

    public int getId()
    {
        return id;
    }
}
