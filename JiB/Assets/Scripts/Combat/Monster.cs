using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster 
{
    public string name;
    public int totalHP;
    public int curHP;
    public float atk;
    public float magAtk;
    public float def;
    public float magDef;
    public float speed;

    public abstract void takeTurn(Arcana[] a);
}
