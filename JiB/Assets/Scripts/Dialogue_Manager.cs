using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dialogue_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //passes along behavior for selected buttons
    public abstract void ButtonClicked(GameObject button);
}
