using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StatGenerator
{
    public int generateHP(int lvl);

    public int generateAtk(int lvl);

    public int generateMagAtk(int lvl);

    public int generateDef(int lvl);

    public int generateMagDef(int lvl);
}
