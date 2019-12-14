using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animation : MonoBehaviour
{
    public Animator animator;
    public float speed = 2f;
    public bool responded = false;
    public bool talking = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < 1 && responded == false)
        {
            animator.SetBool("Talking", true);
            talking = true;
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (responded == false && talking == true)
        {
            UpdateExpression();
        }
    }

    public void EndConvo()
    {
        responded = true;
        animator.SetBool("Responded", true);
        animator.SetBool("Talking", false);
    }

    public void UpdateExpression()
    {
        if (this.tag == "Nancy")
        {
            if (pointManager.PosResponse == true || pointManager.NeuResponse == true || pointManager.NegResponse == true)
            {
                animator.SetBool("HappyNancy", true);
            }
        }
        else if (this.tag == "Josh")
        {
            if (pointManager.PosResponse == true || pointManager.NeuResponse == true)
            {
                animator.SetBool("LaughJosh", true);
            }
            else if (pointManager.NegResponse == true)
            {
                animator.SetBool("PokerJosh", true);
            }
        }
        else if (this.tag == "Cody")
        {
            if (pointManager.PosResponse == true)
            {
                animator.SetBool("HappyCody", true);
            }
            else if (pointManager.NegResponse == true)
            {
                animator.SetBool("ConfusedCody", true);
            }
        }
        else if (this.tag == "Winry")
        {
            if (pointManager.PosResponse == true)
            {
                animator.SetBool("HappyWirny", true);
            }
            else if (pointManager.NegResponse == true)
            {
                animator.SetBool("SadWirny", true);
            }
        }
        else if (this.tag == "Anna")
        {
            if (pointManager.PosResponse == true)
            {
                animator.SetBool("PokerAnna", true);
            }
            else if (pointManager.NegResponse == true)
            {
                animator.SetBool("AngryAnna", true);
            }
        }
        else if (this.tag == "Riley")
        {
            if (pointManager.PosResponse == true)
            {
                animator.SetBool("HappyRiley", true);
            }
            else if (pointManager.NegResponse == true)
            {
                animator.SetBool("DisgustRiley", true);
            }
        }
        else if (this.tag == "Ciel")
        {
            if (IncreaseClick.clicked == 1)
            {
                animator.SetBool("PainCiel", true);
            }
            else if (pointManager.PosResponse == true)
            {
                animator.SetBool("HappyCiel", true);
            }
            else if (pointManager.NegResponse == true)
            {
                animator.SetBool("DisgustCiel", true);
            }
            else
            {
                animator.SetBool("PainCiel", false);
            }
        }
    }
}
