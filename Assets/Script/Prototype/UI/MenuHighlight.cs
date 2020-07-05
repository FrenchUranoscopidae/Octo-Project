using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuHighlight : MonoBehaviour,ISelectHandler, IDeselectHandler
{
    public void OnSelect(BaseEventData pointerEventData)
    {
        gameObject.GetComponentInChildren<Text>().color = Color.white;


    }
    public void OnDeselect(BaseEventData pointerEventData)
    {
        gameObject.GetComponentInChildren<Text>().color = Color.black;

    }
   
}
