using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransferNode : DialogueNode
{
    //for a dialogue node that sends you to a new location and nothing else
    int id;

    public TransferNode(int i)
    {
        id = i;
    }

    public override void Draw()
    {
        SceneManager.LoadScene(id);
    }

    public override DialogueNode requestNext(int clickData)
    {
        return this;
    }
}
