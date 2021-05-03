using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    private string Name;

    private int maxHP;
    public int HP { get; set; }
    public int Dfn { get; set; }

    public int Atk { get; set; }

    public List<Skills> skills;
    private void Awake()
    {
        HP = maxHP;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) TakeDamage(10);
    }
    public void TakeDamage(int damage)
    {
        int realDamage = System.Math.Max(damage - Dfn, 1);
        HP -= realDamage;
        Debug.Log("Took " + realDamage+" Damage");
        if (HP <= 0) Die();
    }

    void Die()
    {
    }
}
