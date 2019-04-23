using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Game : MonoBehaviour
{
    // Start is called before the first frame update
    public void changeScene(string name)
    {
    	Application.LoadLevel(name);
    }
}
