using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creature : MonoBehaviour
{

    public enum Form
    {
        normal,
        upright,
        reveral
    }
    public string Name;

    public Form form;

    public int maxHP;
    public int HP { get; set; }
    public int Dfn { get; set; }

    public int Atk { get; set; }

    public List<Skills> skills;
    private void Awake()
    {
        skills = new List<Skills>();
        skills.Add(new Attack());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) TakeDamage(25, true);

        if (Input.GetKeyDown(KeyCode.Y)) Heal(25);
    }
    public void TakeDamage(int damage, bool ignoreDef = false)
    {
        int realDamage = System.Math.Max(damage - Dfn, 1);
        HP -= realDamage;
        HP = System.Math.Max(HP, 0);
        Debug.Log("Took " + realDamage+" Damage");
        Debug.Log(this.Name + " HP: " + this.HP);
        if (HP <= 0) Die();
    }


    public void Heal(int heal)
    {
        HP += heal;
        HP = System.Math.Min(HP, maxHP);
    }
    void Die()
    {
        SceneManager.LoadScene(0);
    }
}
