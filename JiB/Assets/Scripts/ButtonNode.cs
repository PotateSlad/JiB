using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNode : DialogueNode
{
    //shared in base--
    /*char[] message;
    Text txtbox;
    int character;
    bool proceedable;*/

    DialogueNode[] next;
    int numNext;
    GameObject[] buttons;
    Text[] buttonBoxes;
    string[] buttonText;

    public ButtonNode(string msg, Text txt, GameObject[] b, Text[] t)
    {
        txtbox = txt;
        message = msg.ToCharArray();
        character = 0;
        proceedable = false;
        menuable = 0;

        buttons = b;
        next = new DialogueNode[b.Length];
        buttonText = new string[b.Length];
        numNext = 0;
        buttonBoxes = t;
    }

    //use default draw
    public override void Draw()
    {
        if (proceedable)
        {
            //activate the buttons and set their text!
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(true);
                buttonBoxes[i].text = buttonText[i];
                buttonBoxes[i].gameObject.SetActive(true);
            }
        }
        base.Draw();
    }

    public void addNext(DialogueNode n, string s)
    {
        if (numNext < buttons.Length)
        {
            next[numNext] = n;
            buttonText[numNext] = s;
            numNext++;
        }
    }

    public override DialogueNode requestNext(int clickData)
    {
        if (proceedable && clickData > -1 && clickData < 4)
        {
            if (next.Length == 0)
            {
                return this;
            }
            //any click will work for a clicknode!
            //reset this node
            base.resetNode();
            for (int i = 0; i < buttons.Length; i++)
            {
                //buttons[i];
                buttons[i].SetActive(false);
                buttonBoxes[i].text = "";
                buttonBoxes[i].gameObject.SetActive(false);
            }

            return next[clickData];
        }
        return this;
    }
}
