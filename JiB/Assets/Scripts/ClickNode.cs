using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickNode : DialogueNode
{
    //shared in base--
    /*char[] message;
    Text txtbox;
    int character;
    bool proceedable;
    protected GameObject speaker;
    protected Sprite speakerSprite;
    protected Sprite speakerShadow;
    protected bool speakerLeft;*/

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
            base.resetNode();
            return next;
        }
        return this;
    }
}
