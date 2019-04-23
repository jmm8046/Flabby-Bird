using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    private GameObject heart1;
    private GameObject heart2;
    private GameObject heart3;

    private TestPlayer playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<TestPlayer>();
        heart1 = GameObject.Find("Heart 1");
        heart2 = GameObject.Find("Heart 2");
        heart3 = GameObject.Find("Heart 3");
    }

    // Update is called once per frame
    void Update()
    {
        int playerLife = playerScript.GetLife();

        if (playerLife == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if(playerLife == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        else if(playerLife == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else if(playerLife == 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
    }
}
