using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Component : MonoBehaviour
{
    Map_Camera controller;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponentInParent<Map_Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        Debug.Log("Start moving: " + id);
        controller.startMove(id);
    }
    private void OnMouseExit()
    {
        controller.stopMove(id);
    }
}
