//Made by following the tooltip tutorial at https://www.youtube.com/watch?v=HXFoUGw7eKk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[ExecuteInEditMode()]
public class ToolTipScript2 : MonoBehaviour
{
    public TextMeshProUGUI header;
    public TextMeshProUGUI content;
    public LayoutElement layoutElement;
    public int wrapLimit;

    public void SetText(string contentString, string headerString = "")
    {
        if(string.IsNullOrEmpty(headerString))
        {
            header.gameObject.SetActive(false);
        }
        else
        {
            header.gameObject.SetActive(true);
            header.text = headerString;
        }
        content.text = contentString;
        int headerLength = header.text.Length;
        int contentLength = content.text.Length;

        layoutElement.enabled = (headerLength > wrapLimit || contentLength > wrapLimit) ? true : false;
    }
    
}
//End reference