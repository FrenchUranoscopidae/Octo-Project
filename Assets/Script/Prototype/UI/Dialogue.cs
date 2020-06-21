using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //npc name 
    public string name;

    //modify text area boxes in Button_StartConversation
    [TextArea(3, 10)]

    //sentences load into queue
    public string[] sentences;
}
