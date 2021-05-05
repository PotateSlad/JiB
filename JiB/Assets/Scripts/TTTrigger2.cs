//Made by following the tooltip tutorial at https://www.youtube.com/watch?v=HXFoUGw7eKk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TTTrigger2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string contentString;
    public string headerString;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TTSystem2.Show(contentString, headerString);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       TTSystem2.Hide();
    }
}
//End reference
