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

    [Header("VFX")]
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

    //Function to trigger the dialogue of this object only once
    public void ThisObjectDialogueTrigger()
    {
        dialogueTrigger.TriggerDialogue();
        b_dialogueHappenned = true;
        Debug.Log(b_dialogueHappenned);
    }
}
