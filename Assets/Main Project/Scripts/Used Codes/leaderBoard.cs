using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class leaderBoard : MonoBehaviour
{
    public TMP_Text highScores;
    public float highScore1;
    public static string playerName;

    // Start is called before the first frame update
    void Start()
    {
        highScore1 = gameManager.respectValue / 70 * 100;
        drawScores();
    }

    void drawScores()
    {
        
        highScores.text = playerName + "'s HighScore : " + highScore1.ToString() + "%";
    }

}
