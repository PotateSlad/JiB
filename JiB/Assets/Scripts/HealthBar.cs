using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;

    public Creature creature;

    public float percentile;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Health");
        creature = transform.parent.GetComponent<Creature>();
        //Debug.Log(creature.name + " HP: " + creature.HP);
        //Debug.Log(creature.name + " Max: " + creature.maxHP);
    }

    public void SetSize(float sizeNormalized)
    {
        Debug.Log(sizeNormalized);
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        percentile = ((float) creature.HP) / ((float) creature.maxHP);
        
        SetSize(percentile);
    }
}
