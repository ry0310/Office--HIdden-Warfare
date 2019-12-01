using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialoogueManager : MonoBehaviour
{
    [Header("For main dialogue")]
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    [Header("Response button 1")]
    public GameObject Choice01;
    public TMP_Text choice1Text;

    [Header("Response button 2")]
    public GameObject Choice02;
    public TMP_Text choice2Text;

    [Header("Response button 3")]
    public GameObject Choice03;
    public TMP_Text choice3Text;

    [Header("Continue Button")]
    public GameObject continueButton;

    [Header("Misc")]
    public int choiceMade;

    [Header("Animator")]
    public Animator dialogueAnimator;
    public Animator button1Animator;
    public Animator button2Animator;
    public Animator button3Animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        // Queue for the sentences
        sentences = new Queue<string>();
        //Checks what scene the active scene is
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            //Set all the button text to the appropriate text for the NPC;
            choice1Text.text = "Nice to meet you!";
            choice2Text.text = "Okay";
            choice3Text.text = "...";
        }
        //Checks what scene the active scene is
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            //Set all the button text to the appropriate text for the NPC;
            choice1Text.text = "AHH you got me!";
            choice2Text.text = "Hello nice to be working with you.";
            choice3Text.text = "Okay...";
        }
        //Checks what scene the active scene is
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            //Set all the button text to the appropriate text for the NPC;
            choice1Text.text = "Hello there I'm your new colleague. Nice to meet you!";
            choice2Text.text = "Hi?";
            choice3Text.text = "Why would someboady live here?";
        }
        //Checks what scene the active scene is
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            //Set all the button text to the appropriate text for the NPC;
            choice1Text.text = "Hello Winry, pleasure to be working with you.";
            choice2Text.text = "Okay.";
            choice3Text.text = "Let's not overwork ourselves!";
        }
        //Checks what scene the active scene is
        if (SceneManager.GetActiveScene().name == "Level5")
        {
            //Set all the button text to the appropriate text for the NPC;
            choice1Text.text = "Hello, Anna. Nice to be working with you and thanks for saying hi.";
            choice2Text.text = "Okay.";
            choice3Text.text = "...";
        }
        //Checks what scene the active scene is
        if (SceneManager.GetActiveScene().name == "Level6")
        {
            //Set all the button text to the appropriate text for the NPC;
            choice1Text.text = "Hello Riley, pleasure to be working with you.";
            choice2Text.text = "Hello. Say, are you a guy or a girl?";
            choice3Text.text = "Yeah okay.";
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //These runs the animation for displaying the dialogue and button
        dialogueAnimator.SetBool("isOpen", true);

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            nameText.text = "Nonsence Nancy";
        }
        //Checks what scene the active scene is
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            nameText.text = "Joking Josh";
        }
        //Checks what scene the active scene is
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            nameText.text = "Confused Cody";
        }
        //Checks what scene the active scene is
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            nameText.text = "Worried Winry";
        }
        //Checks what scene the active scene is
        if (SceneManager.GetActiveScene().name == "Level5")
        {
            nameText.text = "Awkward Anna";
        }
        //Checks what scene the active scene is
        if (SceneManager.GetActiveScene().name == "Level6")
        {
            nameText.text = "Relaxed Riley";
        }

        //Clear all the sentences first
        sentences.Clear();

        //Enqueues the sentences to make sure they are in order
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        //Run the function for displaying the next sentence
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0 && choiceMade <= 1)
        {
            continueButton.SetActive(false);
            button1Animator.SetBool("isOpen", true);
            button2Animator.SetBool("isOpen", true);
            button3Animator.SetBool("isOpen", true);
        }
        //Check if there is anymore sentences in the queue and any option buttons have been pressed
        if (sentences.Count == 0 && choiceMade >= 1)
        {
            EndDialogue(); // Run the end dialogue script
            StartCoroutine(finishDialogue()); // 1 second timer before the next scene is run
            return;
        }

        string sentence = sentences.Dequeue(); //dequeue previous sentence

        StopAllCoroutines(); //Stops ALL coroutines to make sure the animation for typing each letter 1 by 1 in a sentences run properly
        StartCoroutine(TypeSentence(sentence)); //Run the function
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = ""; //Set empty sentence to the dialogue text
        foreach(char letter in sentence.ToCharArray()) //Checks every character in the sentence in the array
        {
            dialogueText.text += letter; //Displays 1 by 1
            yield return null;
        }
    }

    IEnumerator finishDialogue()
    {
        yield return new WaitForSeconds(1); //Timer

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Runs the next scene
    }

    void EndDialogue()
    {
        dialogueAnimator.SetBool("isOpen", false); //Run the closing animation for the dialogue
    }

    // Point system
    // positive = +10f
    // netural = +5f
    // negative = -3f

    public void ChoiceOption1()
    {
        //Checks what scene the button is on to show the relevant text
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            dialogueText.text = "Well I got to go back to work now! ";
            gameManager.respectValue += 10f; //Add respect value
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            dialogueText.text = "HA! See you round'! *Laughing Face* ";
            gameManager.respectValue += 10f;
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            dialogueText.text = "What... Nice to meet you too, let's get this bread.";
            gameManager.respectValue += 10f;
        }
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            dialogueText.text = "Right!! Let's get some work started. *Happy face*";
            gameManager.respectValue += 10f;
        }
        if (SceneManager.GetActiveScene().name == "Level5")
        {
            dialogueText.text = "hahahahahahahahahaha *poker face and goes off into the distance*";
            gameManager.respectValue += 10f;
        }
        if (SceneManager.GetActiveScene().name == "Level6")
        {
            dialogueText.text = "Ha ha. Let’s get back to work! *Happy face*";
            gameManager.respectValue += 10f;
        }

        choiceMade = 1;
    }

    public void ChoiceOption2()
    {
        //Checks what scene the button is on to show the relevant text
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            dialogueText.text = "Well I got to go back to work now! ";
            gameManager.respectValue += 5f;
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            dialogueText.text = "HA! See you round'! *Laughing Face* ";
            gameManager.respectValue += 5f;
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            dialogueText.text = "Okay nice to meet you too i guess...";
            gameManager.respectValue -= 3f;
        }
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            dialogueText.text = "Sorry… *Sad face*";
            gameManager.respectValue -= 3f;
        }
        if (SceneManager.GetActiveScene().name == "Level5")
        {
            dialogueText.text = "*frowns and walks off*";
            gameManager.respectValue -= 3f;
        }
        if (SceneManager.GetActiveScene().name == "Level6")
        {
            dialogueText.text = "Heh. *Disgusted face*";
            gameManager.respectValue -= 3f;
        }

        choiceMade = 2;
        gameManager.respectValue += 5f;
    }

    public void ChoiceOption3()
    {
        //Checks what scene the button is on to show the relevant text
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            dialogueText.text = "You're quite the talker!! Back to work now.";
            gameManager.respectValue -= 3f;
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            dialogueText.text = "Well okay I'll be on my way. *Poker face*";
            gameManager.respectValue -= 3f;
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            dialogueText.text = "Sorry...";
            gameManager.respectValue -= 3f;
        }
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            dialogueText.text = "Right!! Let's get some work started. *Happy face*";
            gameManager.respectValue += 10f;
        }
        if (SceneManager.GetActiveScene().name == "Level5")
        {
            dialogueText.text = "*frowns and walks off*";
            gameManager.respectValue -= 3f;
        }
        if (SceneManager.GetActiveScene().name == "Level6")
        {
            dialogueText.text = "Heh. *Disgusted face*";
            gameManager.respectValue -= 3f;
        }

        choiceMade = 3;
    }

    void Update()
    {
        if (choiceMade >= 1) //If a choice has been made
        {
            continueButton.SetActive(true);
            //Run the closing animation
            button1Animator.SetBool("isOpen", false);
            button2Animator.SetBool("isOpen", false);
            button3Animator.SetBool("isOpen", false);
        }
    }
}
