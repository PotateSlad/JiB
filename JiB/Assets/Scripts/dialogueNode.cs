using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueNode
{
    char[] text;
    List<DialogueNode> next;
    Text txtbox;
    bool proceedable;
    bool hasButtons;
    int character;

    Sprite speaker;

    public DialogueNode(string text, Text txtbox, bool buttons)
    {
        this.text = text.ToCharArray();
        this.txtbox = txtbox;
        this.next = new List<DialogueNode>();
        proceedable = false;
        character = 0;
        txtbox.gameObject.transform.localPosition = new Vector3(-1400, -350, 0);
        txtbox.fontSize = 300;
        hasButtons = buttons;
        this.speaker = null;
    }

    public DialogueNode(string text, Text txtbox, Sprite sprite, bool buttons)
    {
        this.text = text.ToCharArray();
        this.txtbox = txtbox;
        this.next = new List<DialogueNode>();
        proceedable = false;
        character = 0;
        txtbox.gameObject.transform.localPosition = new Vector3(-300, -105, 0);
        hasButtons = buttons;
        this.speaker = sprite;
    }

    // Start is called before the first frame update
    public void Draw()
    {
        if (character == 0)
        {
            if (speaker != null)
            {
                GameObject go = new GameObject();
                go.transform.position = new Vector3(-4.4f, -0.9f, -11);
                go.transform.localScale = new Vector3(0.6f, 0.6f, 1);
                SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
                renderer.sprite = Resources.Load("Images/Justice_annoyed", typeof(Sprite)) as Sprite;
            }

            txtbox.text = text[0].ToString();
        }
        else if (character < text.Length)
        {
            txtbox.text += text[character];
        }
        if (character < text.Length)
        {
            character++;
        }
        else
        {
            proceedable = true;
        }
        
    }

    public bool canProceed()
    {
        return proceedable;
    }

    public void addNext(DialogueNode n)
    {
        //only allow the addition of click-next nodes if there's only one
        //and there's no buttons
        if (next.Count < 1 && !hasButtons)
        {
            next.Add(n);
            Debug.Log("Added a node!");
        }
    }

    public void addNext(DialogueNode n, string buttonText)
    {
        //only allow button nodes if the node has buttons
        if (hasButtons)
        {

        }
    }

    public DialogueNode getNext()
    {
        Debug.Log("Returning the next node...");
        if (!hasButtons)
        {
            return next[0];
        }
        return next[0];
    }
}
