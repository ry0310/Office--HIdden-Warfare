using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PrologueManager : MonoBehaviour
{
    public int choiceMade = 0;

    public TMP_Text blackScreen;
    public TMP_Text dialText;

    [Header("Response button 1")]
    public GameObject button1;
    public TMP_Text button1Text;

    [Header("Response button 2")]
    public GameObject button2;
    public TMP_Text button2Text;

    [Header("Animator")]
    public Animator blackScr;
    public Animator dialogueText;
    public Animator button1TextAnimator;
    public Animator button2TextAnimator;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startPrologue());
    }

    void Update()
    {
        if (choiceMade == 0)
        {
            dialText.text = "Tell me about yourself.";

            button1Text.text = "I’m Smart.";
            button2Text.text = "I’m Brave.";
        }
        if (choiceMade == 1)
        {
            dialText.text = "Do you do well in a team?";

            button1Text.text = "I’m a Team Leader.";
            button2Text.text = "I’m a Team Player.";
        }
        if (choiceMade == 2)
        {
            StartCoroutine(fadingOut());
        }
    }

    IEnumerator fadingOut()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator startPrologue()
    {
        yield return new WaitForSeconds(1);
        blackScr.SetBool("isOpen", true);
        dialogueText.SetBool("isOpen", true);
        yield return new WaitForSeconds(1);
        button1TextAnimator.SetBool("isOpen", true);
        button2TextAnimator.SetBool("isOpen", true);
    }

    public void pressed()
    {
        choiceMade += 1;
        Debug.Log("add 1 point");
        StartCoroutine(restartButton());
    }

    IEnumerator restartButton()
    {
        dialogueText.SetBool("isOpen", false);
        button1TextAnimator.SetBool("isOpen", false);
        button2TextAnimator.SetBool("isOpen", false);

        yield return new WaitForSeconds(1);

        dialogueText.SetBool("isOpen", true);
        button1TextAnimator.SetBool("isOpen", true);
        button2TextAnimator.SetBool("isOpen", true);
    }
}
