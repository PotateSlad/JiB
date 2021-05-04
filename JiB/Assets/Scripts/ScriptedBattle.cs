using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedBattle : MonoBehaviour
{
    Justice justice;

    Shoggoth shoggoth;

    int turn;
    // Start is called before the first frame update
    private void Start()
    {
        shoggoth = GameObject.FindObjectOfType<Shoggoth>();

        justice = GameObject.FindObjectOfType<Justice>();

        turn = 0;

    }

    private void Update()
    {
        if (turn % 2 == 0)
        {
            shoggoth.skills[0].DoCombat(shoggoth, justice);
            turn++;
        }
    }

}
