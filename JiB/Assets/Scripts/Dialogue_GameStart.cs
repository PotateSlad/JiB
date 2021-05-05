using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_GameStart : MonoBehaviour
{
    public GameObject gameObject;
    Text txt;
    DialogueNode start;
    DialogueNode curNode;

    // Start is called before the first frame update
    void Start()
    {
        txt = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>();
        start = new DialogueNode("........", txt, false);
        start.addNext(new DialogueNode("This is the second node", txt, false));

        curNode = start;
    }

    // Update is called once per frame
    void Update()
    {
        curNode.Draw();
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Requesting next node...");
            curNode = curNode.getNext();
        }
    }
}
