using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueNode : MonoBehaviour
{
    string[] lines;
    dialogueNode[] next;

    int currentLine;

    dialogueNode(string[] lines, dialogueNode[] next)
    {
        this.lines = lines;
        this.next = next;
        currentLine = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
