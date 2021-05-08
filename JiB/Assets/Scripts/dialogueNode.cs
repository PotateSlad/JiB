using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class DialogueNode
{
    //some positions for text
    //text in the textbox, no character images OR image on the left
    private static Vector3 boxCenterPosition = new Vector3(0, -350, 0);
    private static float boxCenterScale = 11400f;
    private static Vector3 boxLeftPosition = new Vector3(-600, -350, 0);
    private static float boxLeftScale = 6400f;
    //character image on the left
    private static Vector3 boxRightPosition = new Vector3(430, -350, 0);
    private static float boxRightScale = 7800f;

    protected char[] message;
    protected Text txtbox;
    protected int character;
    protected bool proceedable;
    protected bool proceedOnScroll = false;
    protected GameObject speaker;
    protected Sprite speakerSprite;
    protected bool speakerLeft;
    protected bool menuable;

    //adds one more character to the current dialogue box
    public virtual void Draw()
    {
        if (character == 0)
        {
            if (speaker != null)
            {
                speaker.SetActive(true);
                speaker.GetComponent<SpriteRenderer>().sprite = speakerSprite;
                if (speakerLeft)
                {
                    txtbox.transform.localPosition = boxRightPosition;
                    txtbox.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, boxRightScale);
                }
                else
                {
                    txtbox.transform.localPosition = boxLeftPosition;
                    txtbox.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, boxLeftScale);
                }
            }
            else
            {
                txtbox.transform.localPosition = boxCenterPosition;
                txtbox.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, boxCenterScale);
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

        //scroll if more than 4 lines are up
        if (txtbox.cachedTextGenerator.lineCount > 4)
        {
            int i = txtbox.cachedTextGenerator.lines[1].startCharIdx;
            txtbox.text = txtbox.text.Substring(i);
            if (proceedOnScroll)
            {
                proceedable = true;
            }
        }

    }

    public void addSpeaker(GameObject s, string p, bool isLeft)
    {
        speaker = s;
        speakerSprite = Resources.Load(p, typeof(Sprite)) as Sprite;
        speakerLeft = isLeft;
    }

    public void resetNode()
    {
        character = 0;
        proceedable = false;
        if (speaker != null)
        {
            speaker.SetActive(false);
        }
    }

    public abstract DialogueNode requestNext(int clickData);

    public void setProceedableOnScroll(bool b)
    {
        proceedOnScroll = b;
    }

    public void enableMenu()
    {
        menuable = true;
    }
    public bool showMenu()
    {
        return menuable;
    }
}
