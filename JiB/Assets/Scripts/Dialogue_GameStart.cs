using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_GameStart : Dialogue_Manager
{
    Text txt;
    ClickNode start;
    DialogueNode curNode;

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
        ButtonNode second = new ButtonNode("Coo... Coo...", txt, new GameObject[]{ Button1, Button2 }, new Text[] { ButtonBox1, ButtonBox2 });
        ClickNode second_decision1 = new ClickNode("So it's true!", txt);
        ClickNode second_decision2 = new ClickNode("Oh, that's too bad...", txt);

        start.setNext(second);

        second.addNext(second_decision1, "Yes");
        second.addNext(second_decision2, "No");

        second_decision1.setNext(start);

        second_decision2.setNext(start);
        
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
        curNode.Draw();
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
