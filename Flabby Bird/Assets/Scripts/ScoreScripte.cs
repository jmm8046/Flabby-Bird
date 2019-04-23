using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScripte : MonoBehaviour
{
    // Start is called before the first frame update

    public static int ScoreValue;
    Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }

    public static void resetScore()
    {
    	ScoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text  = "Score: " + ScoreValue;
    }
}
