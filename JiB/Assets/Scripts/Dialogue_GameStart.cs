using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_GameStart : MonoBehaviour
{
    public GameObject gameObject;
    Text txt;
    DialogueNode start;

    // Start is called before the first frame update
    void Start()
    {
        txt = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>();
        start = new DialogueNode("Hello world!", txt);
    }

    // Update is called once per frame
    void Update()
    {
        start.Draw();
    }
}
