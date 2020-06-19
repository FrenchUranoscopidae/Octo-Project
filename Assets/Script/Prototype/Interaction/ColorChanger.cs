using System.Collections;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private ColorManager colorMgr;
    private bool canSwap = true;

    //Introductions DialogueTriggering
    public bool b_dialogueHappenned = false;
    public DialogueTrigger dialogueTrigger;

    public AudioClip colorSwapSound;
    public GameObject colorSwapVisualEffect;

    void Start()
    {
        colorMgr.Initialize(GetComponent<SkinnedMeshRenderer>());
        colorMgr.InitializeObjectRenderer(GetComponent<MeshRenderer>());
    }

    public void SwapColors(ColorManager playerColorMgr)
    {
        if (!canSwap) return; // Do nothing if we can't swap colors
        colorMgr.SwapObjectColors(playerColorMgr);
        StartCoroutine(SwapColorsTimer()); // Start the canSwap timer
        AudioSource.PlayClipAtPoint(colorSwapSound, transform.position);
        Instantiate(colorSwapVisualEffect, transform.position, transform.rotation);
        Destroy(GameObject.Find("ColorSwap(Clone)"), 2f);

        //DialogueTriggering
        if (!b_dialogueHappenned)
        {
            ThisObjectDialogueTrigger();
        }
    }

    private IEnumerator SwapColorsTimer()
    {
        canSwap = false;
        yield return new WaitForSeconds(1f);
        canSwap = true;
    }

    /*private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            //DialogueTriggering
            if (!b_dialogueHappenned)
            {
                ThisObjectDialogueTrigger();
            }
        }
    }*/

    //Function to trigger the dialogue of this object only once
    public void ThisObjectDialogueTrigger()
    {
        dialogueTrigger.TriggerDialogue();
        b_dialogueHappenned = true;
        Debug.Log(b_dialogueHappenned);
    }
}
