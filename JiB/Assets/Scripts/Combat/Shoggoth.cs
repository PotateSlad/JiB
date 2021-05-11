using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoggoth : Monster
{
    /*
    public string name;
    public int totalHP;
    public int curHP;
    public float atk;
    public float magAtk;
    public float def;
    public float magDef;
    public float speed;*/

    public Shoggoth()
    {
        name = "Shoggoth";
        totalHP = 300;
        curHP = totalHP;
        atk = 10;
        magAtk = 2;
        def = 5;
        magDef = 1;
        speed = 5;
    }

    public override void takeTurn(Arcana[] a)
    {
        //TODO
    }
}
