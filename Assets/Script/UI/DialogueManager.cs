using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // keep track of all the sentences(string) in the current dialogue
    private Queue<string> sentences;

    //variable for UI display
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    //timer until next sentence;
    public float nextSentenceTimer;
    float nextSentenceTimerReset;
    public bool b_nextSentenceTimerRunning = false;

    void Start()
    {
        sentences = new Queue<string>();
        nextSentenceTimerReset = nextSentenceTimer;
    }

    private void Update()
    {
        if(b_nextSentenceTimerRunning)
        {
            nextSentenceTimer -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            DisplayNextSentence();
            nextSentenceTimer = nextSentenceTimerReset;
        }

        if(nextSentenceTimer <= 0)
        {
            /*if (Input.GetKeyDown(KeyCode.A))
            {
                DisplayNextSentence();
                nextSentenceTimer = nextSentenceTimerReset;
            }*/
            DisplayNextSentence();
            nextSentenceTimer = nextSentenceTimerReset;
        }

        //Debug.Log(nextSentenceTimer);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        Debug.Log("Starting conversation with" + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //if there is no sentences in the queue
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //if there is still sentences in the queue
        string sentence = sentences.Dequeue();

        nextSentenceTimer = nextSentenceTimerReset;
        b_nextSentenceTimerRunning = true;

        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation.");
        b_nextSentenceTimerRunning = false;
    }
}
