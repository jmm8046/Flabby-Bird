using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private TestPlayer playerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript = collision.gameObject.GetComponent<TestPlayer>();

        playerScript.PlayerCollide(gameObject.tag);
    }
}
