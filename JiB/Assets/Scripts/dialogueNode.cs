using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueNode
{
    string text;
    List<DialogueNode> next;
    Text txtbox;

    Sprite speaker;

    public DialogueNode(string text, Text txtbox)
    {
        this.text = text;
        this.txtbox = txtbox;
        this.next = new List<DialogueNode>();
        this.speaker = null;
    }

    public DialogueNode(string text, Text txtbox, Sprite sprite)
    {
        this.text = text;
        this.txtbox = txtbox;
        this.next = new List<DialogueNode>();
        this.speaker = sprite;
    }

    // Start is called before the first frame update
    public void Draw()
    {
        txtbox.text = next.Count.ToString();
    }
}
