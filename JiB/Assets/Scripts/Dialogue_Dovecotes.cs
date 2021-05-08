using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Dovecotes : Dialogue_Manager
{
    Text txt;
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
        if (!Game.gameIsInit)
        {
            Game.gameInit();
        }

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

        if (Game.mapStatus[(int)Game.MapIDs.Dovecotes] == (int)Game.MapStatus.Unvisited_Green)
        {
            //set dovecotes to visited green
            Game.mapStatus[(int)Game.MapIDs.Dovecotes] = (int)Game.MapStatus.Visited_Green;

            ClickNode n_1 = new ClickNode("No wonder my head hurts...", txt);
            n_1.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);

            ClickNode n_2 = new ClickNode("Wait... Why the Dovecotes?", txt);
            n_2.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);
            n_1.setNext(n_2);

            ClickNode n_3 = new ClickNode("Doves are for peace!", txt);
            n_3.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_2.setNext(n_3);

            ButtonNode n_4 = new ButtonNode("Uh.......... huh.........", txt, 
                new GameObject[] { Button1, Button2, Button3 }, new Text[] { ButtonBox1, ButtonBox2, ButtonBox3 });
            n_4.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);
            n_3.setNext(n_4);
            //for loop return
            ButtonNode n_4b = new ButtonNode("Hm.", txt,
                new GameObject[] { Button1, Button2, Button3, Button4 }, new Text[] { ButtonBox1, ButtonBox2, ButtonBox3, ButtonBox4 });
            n_4b.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);

            
            //branch n_4_a
            ClickNode n_4_a1 = new ClickNode("Did you see who opened the portal?", txt);
            n_4_a1.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);

            ClickNode n_4_a2 = new ClickNode("Oh, uh... No...\n\nBut that's not for lack of trying! " +
                "It just kind of... appeared.", txt);
            n_4_a2.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_4_a1.setNext(n_4_a2);

            ClickNode n_4_a3 = new ClickNode("I don't know if any of us has magic THAT strong, though. " +
                "My hammer didn't do a thing to those monsters!", txt);
            n_4_a3.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_4_a2.setNext(n_4_a3);

            n_4_a3.setNext(n_4b);

            //branch n_4_b
            ClickNode n_4_b1 = new ClickNode("Sorry, must've gotten hit real hard.\n\nCan you start that again, " +
                "from the top? Maybe a bit slower.", txt);
            n_4_b1.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);

            ClickNode n_4_b2 = new ClickNode("Oh no, do you need medical attention?!", txt);
            n_4_b2.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_4_b1.setNext(n_4_b2);

            ClickNode n_4_b3 = new ClickNode("I- Uh, no. Something about a portal?", txt);
            n_4_b3.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);
            n_4_b2.setNext(n_4_b3);

            ClickNode n_4_b4 = new ClickNode("Yeah! All the Major Arcana were in the Great Hall for the meeting today...\n" +
                "Everything was going totally normal until that portal opened up behind Tower on the dias.", txt);
            n_4_b4.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_4_b3.setNext(n_4_b4);

            ClickNode n_4_b5 = new ClickNode("It wasn't anything like any portal I'd ever seen before. Like someone'd " +
                "ripped a hole in a piece of fabric, only it was in mid-air, all the way from floor to ceiling!", txt);
            n_4_b5.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_4_b4.setNext(n_4_b5);

            ClickNode n_4_b6 = new ClickNode("Then this huge set of claws reached out from it and pulled the portal open. " +
                "It was the worst thing I'd ever seen, Justice!", txt);
            n_4_b6.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_4_b5.setNext(n_4_b6);

            ClickNode n_4_b6b = new ClickNode("It was big and horrible, like some awful, misshapen animal. " +
                "It looked like it was made of pitch and dripped black goo everywhere and smelled like " +
                "rotten eggs!", txt);
            n_4_b6b.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_4_b6.setNext(n_4_b6b);

            ClickNode n_4_b7 = new ClickNode("Of course, as soon as that one was out, a bunch of other monsters came " +
                "after it, all different but just as gross. ", txt);
            n_4_b7.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_4_b6b.setNext(n_4_b7);

            ClickNode n_4_b7b = new ClickNode("The Emperor and Empress started trying to fight them, " +
                "but even they were having trouble keeping them at bay. It wasn't long until they told everyone to evacuate.", txt);
            n_4_b7b.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_4_b7.setNext(n_4_b7b);

            ClickNode n_4_b8 = new ClickNode("I tried to help Tower, but I couldn't even get near her! " +
                "And when Empress told me to leave, that's when I saw you get knocked upside the head.", txt);
            n_4_b8.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_4_b7b.setNext(n_4_b8);

            ClickNode n_4_b9 = new ClickNode("Sounds like I really should've been watching where I was standing.", txt);
            n_4_b9.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);
            n_4_b8.setNext(n_4_b9);

            n_4_b9.setNext(n_4b);

            //branch n_4_c
            ClickNode n_4_c1 = new ClickNode("Did you see anyone else get out of the Hall?", txt);
            n_4_c1.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);

            ClickNode n_4_c2 = new ClickNode("No, sorry...\n\nEverything kinda happened all at once.", txt);
            n_4_c2.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_4_c1.setNext(n_4_c2);

            ClickNode n_4_c3 = new ClickNode("Those monsters from the portal were pouring into the rest " +
                "of the castle by the time I got you out of there.", txt);
            n_4_c3.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_4_c2.setNext(n_4_c3);

            ClickNode n_4_c4 = new ClickNode("But it looks like at least this side of the castle grounds is still clear.", txt);
            n_4_c4.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_4_c3.setNext(n_4_c4);

            ClickNode n_4_c5 = new ClickNode("I'm sure Hermit is having a field day.", txt);
            n_4_c5.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);
            n_4_c4.setNext(n_4_c5);

            n_4_c5.setNext(n_4b);

            //end branch
            ClickNode n_5 = new ClickNode("Let's get out of here.\n\nIf we're going to catch who did this, which we " +
                "are, we'd better start looking sooner rather than later.", txt);
            n_5.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);
            
            n_4.addNext(n_4_b1, "Again... But slower.");
            n_4.addNext(n_4_a1, "Who did it?");
            n_4.addNext(n_4_c1, "Who else got out?");

            n_4b.addNext(n_4_a1, "Who did it?");
            n_4b.addNext(n_4_c1, "Who else got out?");
            n_4b.addNext(n_5, "Let's get out of here.");
            n_4b.addNext(n_4_b1, "Again... But slower.");

            ClickNode n_6 = new ClickNode("Oh geez, Justice. The portal is still open and the castle is swarming " +
                "with monsters! You can't tell me you're gonna try and do your judge thing in all that...", txt);
            n_6.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_5.setNext(n_6);

            ButtonNode n_7 = new ButtonNode(".....", txt, new GameObject[] { Button1, Button2 }, new Text[] { ButtonBox1, ButtonBox2 });
            n_7.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);
            n_6.setNext(n_7);

            //branch n_7a
            ClickNode n_7_a1 = new ClickNode("Isn't your name Strength? I figured you'd be the first one " +
                "back in there, trying to rescue as many of the Arcana as you could.", txt);
            n_7_a1.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);

            ClickNode n_7_a2 = new ClickNode("The Strength I know would be gathering her army and tending " +
                "to the wounded right away. The quicker you move, the less people get hurt.", txt);
            n_7_a2.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);
            n_7_a1.setNext(n_7_a2);

            ClickNode n_7_a3 = new ClickNode("I... you're right, Justice. We've gotta figure out a way to stop those monsters!", txt);
            n_7_a3.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_7_a2.setNext(n_7_a3);

            //branch n_7b
            ClickNode n_7_b1 = new ClickNode("I am. You don't have to join if you don't want to, Strength, " +
                "but I can't rest if the scales are this far out of balance.", txt);
            n_7_b1.addSpeaker(SpeakerLeft, "Images/justice_annoyed", true);

            ClickNode n_7_b2 = new ClickNode("Oh Justice... I can't just let you get yourself torn apart all alone. Fine.", txt);
            n_7_b2.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_7_b1.setNext(n_7_b2);

            //end branch
            n_7.addNext(n_7_a1, "Aren't you Strength?");
            n_7.addNext(n_7_b1, "You don't have to join.");

            ClickNode n_8 = new ClickNode("First things first...", txt);
            n_8.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_7_a3.setNext(n_8);
            n_7_b2.setNext(n_8);

            ClickNode n_9 = new ClickNode("", txt);

            curNode = n_1;
        }
        else //status is Visited Green
        {
            ButtonNode n_1 = new ButtonNode("Coo... Coo...", txt, new GameObject[] { Button1 }, new Text[] { ButtonBox1 });

            curNode = n_1;
        }
        

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

        
    }

    //FixedUpdate is called on a regular time interval
    private void FixedUpdate()
    {
        if (curNode.showMenu() == true)
        {

        }
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
