using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBtn : MonoBehaviour
{
    public CombatManager controller;
    private bool enabled = true;

    public void disableButton()
    {
        enabled = false;
        Debug.Log("Disabling attack button!");
    }

    private void OnMouseUp()
    {
        if (enabled)
        {
            controller.processAttack();
        }
    }
}
