using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public Dialogue_Manager controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("DialogueManager").GetComponent<Dialogue_Manager>();
    }

    // Update is called once per frame
    void OnMouseUp()
    {
        controller.ButtonClicked(this.transform.gameObject);
    }
}
