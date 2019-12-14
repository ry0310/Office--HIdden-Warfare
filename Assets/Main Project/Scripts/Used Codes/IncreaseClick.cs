using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseClick : MonoBehaviour
{
    public static int clicked = 0;

    public void ClickedB()
    {
        clicked += 1;
        Debug.Log(clicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
