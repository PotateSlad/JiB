using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRoom : MonoBehaviour
{
    public bool hideOnLocked;
    private bool isLocked = false;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        if (!Game.gameIsInit)
        {
            Game.gameInit();
        }

        Game.MapIDs m;

        Enum.TryParse(this.name, out m);

        int status = Game.mapStatus[(int)m];
        sr = GetComponent<SpriteRenderer>();
        Color green = new Color(113 / 255f, 214 / 255f, 62 / 255f, 100 / 255f);
        Color yellow = new Color(255 / 255f, 248 / 255f, 74 / 255f, 100 / 255f);
        Color red = new Color(200 / 255f, 23 / 255f, 0 / 255f, 100 / 255f);
        Color white = new Color(255 / 255f, 255 / 255f, 255 / 255f, 30 / 255f);

        if (status == (int)Game.MapStatus.Unvisited_Green || status == (int)Game.MapStatus.Visited_Green)
        {
            sr.color = green;
        }
        else if (status == (int)Game.MapStatus.Unvisited_Yellow || status == (int)Game.MapStatus.Visited_Yellow)
        {
            sr.color = yellow;
        }
        else if (status == (int)Game.MapStatus.Unvisited_Red || status == (int)Game.MapStatus.Visited_Red)
        {
            sr.color = red;
        }
        else //locked
        {
            sr.color = white;
            isLocked = true;
            if (hideOnLocked)
            {
                this.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    private void OnMouseEnter()
    {
        if (!isLocked)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a + (40 / 255f));
        }
    }

    private void OnMouseExit()
    {
        if (!isLocked)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - (40 / 255f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
