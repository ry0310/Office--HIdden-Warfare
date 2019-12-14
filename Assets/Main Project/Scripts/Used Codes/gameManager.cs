using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static float respectValue = 0f;


    void Start()
    {
        GUI.FocusControl(null);
    }

        public void endScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        IncreaseClick.clicked = 0; // Reset the clicked and response values
        pointManager.PosResponse = false;
        pointManager.NeuResponse = false;
        pointManager.NegResponse = false;

        
    }

    public void colEndScene(Collision collision)
    {
        if(collision.gameObject.tag == "Leave")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            IncreaseClick.clicked = 0; // Reset the clicked and response values
            pointManager.PosResponse = false;
            pointManager.NeuResponse = false;
            pointManager.NegResponse = false;
        }
    }
}   
