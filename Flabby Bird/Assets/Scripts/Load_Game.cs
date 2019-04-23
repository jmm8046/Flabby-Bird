using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Load_Game : MonoBehaviour
{ 
    public void loadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void loadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }
}
