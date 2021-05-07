using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class DialogueNode
{
    //some positions for text
    //text in the textbox, no character images OR image on the left
    private static Vector3 boxLeftPosition = new Vector3(-1400, -350, 0);
    //character image on the left
    private static Vector3 boxRightPosition = new Vector3(-300, -105, 0);

    protected char[] message;
    protected Text txtbox;
    protected int character;
    protected bool proceedable;

    //adds one more character to the current dialogue box
    public virtual void Draw()
    {
        if (character == 0)
        {
            txtbox.text = message[0].ToString();
        }
        else if (character < message.Length)
        {
            txtbox.text += message[character];
        }
        if (character < message.Length)
        {
            character++;
        }
        else
        {
            proceedable = true;
        }

    }

    public abstract DialogueNode requestNext(int clickData);

}
