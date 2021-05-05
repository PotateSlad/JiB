using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcana
{
    private string name;
    private int id;
    private int level;
    private int exp;
    private int totalHP;
    private int curHP;
    private int atk;
    private int magAtk;
    private int def;
    private int magDef;

    private StatGenerator sg;

    public Arcana(int i)
    {
        id = i;
        name = Game.TarotNames[id];

        //select a proper stat generator
        //fighters
        if (id == (int)Game.Tarot.Justice)
        {
            sg = new FighterStatGenerator();
        }

        //for testing we'll just default...
        sg = new FighterStatGenerator();

        level = 0;
        exp = 0;
        totalHP = 0;
        curHP = 0;
    }

    //for leveling up or setting the first time
    public void updateStats(int lvl)
    {
        level = lvl;
        totalHP = sg.generateHP(level);
        //leveling up will heal a character to full HP
        curHP = totalHP;
        atk = sg.generateAtk(level);
        magAtk = sg.generateMagAtk(level);
        def = sg.generateDef(level);
        magDef = sg.generateMagDef(level);
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

    public int getId()
    {
        return id;
    }
    public int getLevel()
    {
        return level;
    }
    public int getExp()
    {
        return exp;
    }
}
