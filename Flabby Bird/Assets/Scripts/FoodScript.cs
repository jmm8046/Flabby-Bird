using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private ScrollManager scrollManager;

    private TestPlayer playerScript;

    void Start()
    {
        scrollManager = GameObject.Find("Scroll Manager").GetComponent<ScrollManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript = collision.gameObject.GetComponent<TestPlayer>();

        playerScript.PlayerCollide(gameObject.tag);
        scrollManager.RemoveObject(gameObject);
        Destroy(gameObject);
    }
}
