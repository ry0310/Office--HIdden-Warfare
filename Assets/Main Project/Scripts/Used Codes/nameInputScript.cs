using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class nameInputScript : MonoBehaviour
{
    public InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leaderBoard.playerName = nameInput.text;
    }

    public void buttonToNextScene()
    {
        if (nameInput.text != "")
        {
            GUI.FocusControl(null);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
}
