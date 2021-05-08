using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_GameStart : Dialogue_Manager
{
    Text txt;
    ClickNode start;
    DialogueNode curNode;
    int speed = 2;
    int counter = 1;

    //composite parts of the manager to set up...
    GameObject Button4;
    GameObject Button1;
    GameObject Button2;
    GameObject Button3;
    Text ButtonBox4;
    Text ButtonBox1;
    Text ButtonBox2;
    Text ButtonBox3;
    GameObject SpeakerLeft;
    GameObject SpeakerRight;

    // Start is called before the first frame update
    void Start()
    {
        txt = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>();
        Button4 = GameObject.Find("Button4");
        Button1 = GameObject.Find("Button1");
        Button2 = GameObject.Find("Button2");
        Button3 = GameObject.Find("Button3");
        ButtonBox4 = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(4).gameObject.GetComponent<UnityEngine.UI.Text>();
        ButtonBox1 = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<UnityEngine.UI.Text>();
        ButtonBox2 = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.GetComponent<UnityEngine.UI.Text>();
        ButtonBox3 = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.GetComponent<UnityEngine.UI.Text>();
        SpeakerLeft = GameObject.Find("SpeakerLeft");
        SpeakerRight = GameObject.Find("SpeakerRight");

        start = new ClickNode("......................", txt);
        ButtonNode n_2 = new ButtonNode("Coo...   Coo...", txt, 
                            new GameObject[]{ Button1, Button2 }, new Text[] { ButtonBox1, ButtonBox2 });
        start.setNext(n_2);

        //branch 2_1
        ClickNode n_2_1 = new ClickNode("Justice! You're awake!", txt);
        n_2.addNext(n_2_1, "What the hell is that?");
        ClickNode n_2_1_b = new ClickNode("Strength?\n\nWhat the hell is all that cooing?", txt);
        n_2_1_b.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);
        n_2_1.setNext(n_2_1_b);
        ClickNode n_2_1_1 = new ClickNode("That?... \n\nOh, it's the doves!", txt);
        n_2_1_1.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
        n_2_1_b.setNext(n_2_1_1);
        ClickNode n_2_1_2 = new ClickNode("You know, the doves that live in the Dovecotes.", txt);
        n_2_1_2.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
        n_2_1_1.setNext(n_2_1_2);

        //branch 2_2
        ClickNode n_2_2 = new ClickNode("Justice! You're awake!", txt);
        n_2.addNext(n_2_2, "Where the hell am I?");
        ClickNode n_2_2_b = new ClickNode("Strength, where the hell am I.", txt);
        n_2_2_b.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);
        n_2_2.setNext(n_2_2_b);
        ClickNode n_2_2_1 = new ClickNode("Wha?... \n\nOh, you're in the Dovecotes, silly!", txt);
        n_2_2_1.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
        n_2_2_b.setNext(n_2_2_1);

        //branch together
        ButtonNode n_3 = new ButtonNode("I brought you here after, oh geez...\nYou don't remember?\n\n" +
                                        "Well, we were all just in the Great Hall for the Monday meeting, " +
                                        "and Tower had just gone up to the dias to read off some requests, " +
                                        "then WHOOOOSH and a HUGE scary-looking portal ripped open behind her " +
                                        "and a bunch of GIANT monsters came out of it! I'll tell you Justice, " +
                                        "I've never seen anything like them! Anyway, everyone started trying " +
                                        "to fight them off, but it didn't look like anything was working, so " +
                                        "we started trying to get Tower away from them because she sure was " +
                                        "taking a beating. Anyway, you were just standing there going \"blah " +
                                        "blah Strength what's happening\" and JUST as I was about to tell you " +
                                        "one of them smacked you upside the head! And you sure went down like a sack " +
                                        "of potatoes, Justice. At that point, things were looking pretty bad, " +
                                        "so I just grabbed you and ran outside, and the Dovecotes looked like " +
                                        "a pretty safe place to go, on account that I didn't see and big scary " +
                                        "monsters outside of the castle and all. Plus the doves are real cute.", txt, 
                                        new GameObject[] { Button1 }, new Text[] { ButtonBox1 });
        n_3.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
        n_3.setProceedableOnScroll(true);
        n_2_2_1.setNext(n_3);
        n_2_1_2.setNext(n_3);

        n_3.addNext(start, "Strength...");
        
        Button4.SetActive(false);
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        ButtonBox4.gameObject.SetActive(false);
        ButtonBox1.gameObject.SetActive(false);
        ButtonBox2.gameObject.SetActive(false);
        ButtonBox3.gameObject.SetActive(false);
        SpeakerLeft.SetActive(false);
        SpeakerRight.SetActive(false);

        curNode = start;
    }

    //FixedUpdate is called on a regular time interval
    private void FixedUpdate()
    {
        if (counter == speed)
        {
            curNode.Draw();
            counter = 1;
        }
        counter++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            curNode = curNode.requestNext(-1);
        }
    }

    public override void ButtonClicked(GameObject button)
    {
        int buttonId = int.Parse(button.name.Substring(button.name.Length - 1, 1)) - 1;
        curNode = curNode.requestNext(buttonId);
    }
}
