using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Magician : Dialogue_Manager
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
    GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        if (!Game.gameIsInit)
        {
            Game.gameInit();
        }
        Game.currentRoom = (int)Game.MapIDs.Magician_Tower;

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
        UI = GameObject.Find("UI");

        if (Game.mapStatus[(int)Game.MapIDs.Magician_Tower] == (int)Game.MapStatus.Unvisited_Red)
        {
            //set magician tower to visited green
            Game.mapStatus[(int)Game.MapIDs.Magician_Tower] = (int)Game.MapStatus.Visited_Green;

            ClickNode n_1 = new ClickNode("As you walk into the Magician's Tower, you hear a faint chittering " +
                "above you...", txt);

            ClickNode n_2 = new ClickNode("Watch out!", txt);
            n_2.addSpeaker(SpeakerRight, "Images/strength_neutral", false);
            n_1.setNext(n_2);

            TransferNode n_3 = new TransferNode(1);
            n_2.setNext(n_3);

            curNode = n_1;
        }
        else //status is Visited Green
        {
            ClickNode n_1 = new ClickNode("Congratulations, you beat the monster!", txt);

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
        UI.SetActive(false);
    }

    //FixedUpdate is called on a regular time interval
    private void FixedUpdate()
    {
        if (curNode.showMenu() == 1)
        {
            UI.SetActive(true);
        }
        else if (curNode.showMenu() == -1)
        {
            UI.SetActive(false);
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
