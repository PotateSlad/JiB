//Made by following the tooltip tutorial at https://www.youtube.com/watch?v=HXFoUGw7eKk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTSystem2 : MonoBehaviour
{
    private static TTSystem2 current;
    public ToolTipScript2 tooltip;

    public void Awake()
    {
        current = this;
    }

    public static void Show(string contentString, string headerString = "")
    {
        current.tooltip.SetText(contentString, headerString);
        current.tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        current.tooltip.gameObject.SetActive(false);
    }

    public static void Start()
    {
        Hide();
    }
}
//End reference