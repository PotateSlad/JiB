using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Justice : Creature
{
    private readonly int MaxHP = 100;

    private void Awake()
    {
        this.Dfn = 20;
        Atk = 20;
        HP = MaxHP;
    }
}
