using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStatGenerator : StatGenerator
{
    public int generateHP(int lvl)
    {
        return (10 * lvl) + 100;
    }

    public int generateAtk(int lvl)
    {
        return (5 * lvl) + 20;
    }

    public int generateMagAtk(int lvl)
    {
        return (2 * lvl) + 15;
    }

    public int generateDef(int lvl)
    {
        return (4 * lvl) + 20;
    }

    public int generateMagDef(int lvl)
    {
        return (2 * lvl) + 15;
    }
}
