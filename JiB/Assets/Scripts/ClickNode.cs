using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickNode : DialogueNode
{
    //some positions for text
    //text in the textbox, no character images OR image on the left
    private static Vector3 boxLeftPosition = new Vector3(-1400, -350, 0);
    //character image on the left
    private static Vector3 boxRightPosition = new Vector3(-300, -105, 0);

    //in base--
    /*char[] message;
    Text txtbox;
    int character;
    bool proceedable;*/

    DialogueNode next;

    public ClickNode(string msg, Text txt)
    {
        txtbox = txt;
        message = msg.ToCharArray();
        character = 0;
        proceedable = false;
    }

    //use default draw
    public new void Draw()
    {
        base.Draw();
    }

    public void setNext(DialogueNode n)
    {
        next = n;
    }

    public override DialogueNode requestNext(int clickData)
    {
        if (proceedable)
        {
            //any click will work for a clicknode!
            //reset this node
            character = 0;
            proceedable = false;
            return next;
        }
        return this;
    }
}
