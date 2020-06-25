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

    [Header("VFX")]
    //public GameObject colorSwapThunder1;
    //public GameObject colorSwapThunder2;
    public bool vfxActive = false;

    public ParticleSystem Thunder1;
    public ParticleSystem Thunder2;

    void Start()
    {
        colorMgr.Initialize(GetComponent<SkinnedMeshRenderer>());
        colorMgr.InitializeObjectRenderer(GetComponent<MeshRenderer>());

        Thunder1.Stop();
        Thunder2.Stop();
    }

    public void SwapColors(ColorManager playerColorMgr)
    {
        if (!canSwap) return; // Do nothing if we can't swap colors
        colorMgr.SwapObjectColors(playerColorMgr);
        StartCoroutine(SwapColorsTimer()); // Start the canSwap timer
        AudioSource.PlayClipAtPoint(colorSwapSound, transform.position);
        //Instantiate(colorSwapVisualEffect, transform.position, transform.rotation);
        Destroy(GameObject.Find("ColorSwap(Clone)"), 2f);

        //colorSwapThunder1.SetActive(true);
        //colorSwapThunder2.SetActive(true);

        Thunder1.Play();
        Thunder2.Play();

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
