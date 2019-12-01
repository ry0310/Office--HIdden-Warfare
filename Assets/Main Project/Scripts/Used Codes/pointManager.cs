using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointManager : MonoBehaviour
{
    public void positiveResponse()
    {
        gameManager.respectValue += 10f;
    }
    public void neutralResponse()
    {
        gameManager.respectValue += 5f;
    }
    public void negativeResponse()
    {
        gameManager.respectValue -= 3f;
    }
}
