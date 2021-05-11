using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    private GameObject atkBtn;
    private bool matchOver = false;

    private string[] turnNames;
    private float[] turnSpeeds;
    private int next;

    private GameObject p1;
    private GameObject p2;
    private GameObject p3;
    private GameObject p4;
    private GameObject[] p;

    private GameObject e1;

    private GameObject skillMenu;
    private GameObject textbox;
    private TextMeshPro txt;

    private Arcana[] party;
    private Monster[] monsters;

    // Start is called before the first frame update
    void Start()
    {
        if (!Game.gameIsInit)
        {
            Game.gameInit();
        }

        //setup vars...
        party = Game.party;
        monsters = Game.enemies;
        turnNames = new string[Game.partySize + Game.numMonsters];
        turnSpeeds = new float[turnNames.Length];
        int next = 0;

        foreach (Arcana a in party)
        {
            if (a != null)
            {
                turnNames[next] = a.name;
                turnSpeeds[next] = a.speed;
                next++;
            }
        }
        foreach (Monster m in monsters)
        {
            if (m != null)
            {
                turnNames[next] = m.name;
                turnSpeeds[next] = m.speed;
                next++;
            }
        }

        //get gameobjects...
        p1 = GameObject.Find("Party2");
        p2 = GameObject.Find("Party3");
        p3 = GameObject.Find("Party1");
        p4 = GameObject.Find("Party4");
        p = new GameObject[] { p1, p2, p3, p4 };

        e1 = GameObject.Find("Enemy1");

        skillMenu = GameObject.Find("SkillMenu");
        textbox = GameObject.Find("TextBox");
        txt = textbox.transform.GetChild(0).GetComponent<TextMeshPro>();
        atkBtn = GameObject.Find("AttackBtn");

        //set up images and visibility
        for (int i = 0; i < 4; i++)
        {
            if (i < Game.partySize)
            {
                //TODO
            }
            else
            {
                p[i].SetActive(false);
            }
        }
        skillMenu.SetActive(false);
        e1.transform.GetChild(0).GetComponent<TextMeshPro>().text = "(" + monsters[0].curHP + " / " + monsters[0].totalHP + ")";

        //find first turn
        getNext();
    }

    // Update is called once per frame
    void Update()
    {
        if (matchOver)
        {
            if (Input.GetMouseButtonUp(0))
            {
                SceneManager.LoadScene(6);
            }
        }
        else
        {
            //if it's a monster's turn, take its turn
            Monster m = nextMonster();
            if (m != null)
            {
                txt.text = "It's " + m.name + "'s turn!";
                m.takeTurn(party);

                //update turn map
                turnSpeeds[next] += m.speed;
                getNext();
            }
        }
    }

    //processes an attack, then proceeds to the next Arcana turn
    public void processAttack()
    {
        Arcana a = nextArcana();
        if (a != null)
        {
            a.attack(monsters[0]);
            //update HP in UI
            e1.transform.GetChild(0).GetComponent<TextMeshPro>().text = "(" + monsters[0].curHP + " / " + monsters[0].totalHP + ")";

            //if all the monsters are dead, finish the combat!
            if (allMonstersDead())
            {
                endCombat();
            }
            else
            {
                //update turn map
                turnSpeeds[next] += a.speed;
                getNext();
            }
        }
    }

    public void processSkill(int skillNum)
    {
        Arcana a = nextArcana();
        if (a != null)
        {
            a.attack(monsters[0]);

            //update turn map
            turnSpeeds[next] += a.speed;
            getNext();
        }
    }

    public void getNext()
    {
        //find the lowest entry in the map
        int n = 0;
        float min = 0;
        for (int i = 0; i < turnSpeeds.Length; i++)
        {
            if (turnSpeeds[i] < min)
            {
                min = turnSpeeds[i];
                n = i;
            }
        }
        txt.text = "It's " + turnNames[n] + "'s turn!";
        next = n;
    }

    private void endCombat()
    {
        //disable buttons
        atkBtn.GetComponent<AtkBtn>().disableButton();

        //update text
        txt.text = "You've defeated the monster!";

        matchOver = true;
    }
    
    public Monster nextMonster()
    {
        string n = turnNames[next];
        foreach (Monster m in monsters)
        {
            if (m.name.Equals(n))
            {
                return m;
            }
        }
        return null;
    }
    
    public Arcana nextArcana()
    {
        string n = turnNames[next];
        foreach (Arcana a in party)
        {
            if (a.name.Equals(n))
            {
                return a;
            }
        }
        return null;
    }

    private bool allMonstersDead()
    {
        foreach (Monster m in monsters)
        {
            if (m != null)
            {
                if (m.curHP > 0)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
