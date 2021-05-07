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
    private static Vector3 boxRightPosition = new Vector3(-500, -350, 0);

    protected char[] message;
    protected Text txtbox;
    protected int character;
    protected bool proceedable;
    protected GameObject speaker;
    protected Sprite speakerSprite;
    protected Sprite speakerShadow;
    protected bool speakerLeft;

    //adds one more character to the current dialogue box
    public virtual void Draw()
    {
        if (character == 0)
        {
            if (speaker != null)
            {
                speaker.SetActive(true);
                speaker.GetComponent<SpriteRenderer>().sprite = speakerSprite;
                speaker.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = speakerShadow;
                if (speakerLeft)
                {
                    txtbox.transform.localPosition = boxRightPosition;
                }
            }
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

    public void addSpeaker(GameObject s, string p, string sh, bool isLeft)
    {
        speaker = s;
        speakerSprite = Resources.Load(p, typeof(Sprite)) as Sprite;
        speakerShadow = Resources.Load(sh, typeof(Sprite)) as Sprite;
        speakerLeft = isLeft;
    }

    public void resetNode()
    {
        character = 0;
        proceedable = false;
        if (speaker != null)
        {
            speaker.SetActive(false);
            if (speakerLeft)
            {
                txtbox.transform.localPosition = boxLeftPosition;
            }
        }
    }

    public abstract DialogueNode requestNext(int clickData);

}
