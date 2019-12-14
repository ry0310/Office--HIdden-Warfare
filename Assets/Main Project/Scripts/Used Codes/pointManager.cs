using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointManager : MonoBehaviour
{
    public static bool PosResponse = false;
    public static bool NeuResponse = false;
    public static bool NegResponse = false;

    public void positiveResponse()
    {
        gameManager.respectValue += 10f;
        PosResponse = true;
    }
    public void neutralResponse()
    {
        gameManager.respectValue += 5f;
        NeuResponse = true;
    }
    public void negativeResponse()
    {
        gameManager.respectValue -= 3f;
        NegResponse = true;
    }
}
